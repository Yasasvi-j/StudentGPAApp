using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentGPAApp.Data;
using StudentGPAApp.Models;

namespace StudentGPAApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewBag.Student = new Student(); // for the form

            var students = await _context.Students
                .Include(s => s.Courses) // include related grades
                .ToListAsync();

            // Calculate GPA for each student
            foreach (var student in students)
            {
                student.GPA = CalculateGPA(student.Courses);
            }

            return View(students);
        }

        public async Task<IActionResult> ViewData()
        {
            var students = await _context.Students.Include(s => s.Courses).ToListAsync();
            return View(students);
        }

        // Define this outside the Index method but still inside the controller class
        private double CalculateGPA(List<CourseGrade> courses)
        {
            var gradeMap = new Dictionary<string, double>
            {
                {"A", 4.0}, {"A-", 3.7}, {"B+", 3.3}, {"B", 3.0}, {"B-", 2.7}, {"C+", 2.3}, {"C", 2.0}, {"C-", 1.7}, {"D+", 1.3}, {"D", 1.0}, {"D-", 0.7}, {"F", 0.3}
            };

            var validGrades = courses
                .Where(c => gradeMap.ContainsKey(c.Grade))
                .Select(c => gradeMap[c.Grade])
                .ToList();

            if (!validGrades.Any()) return 0.0;

            return Math.Round(validGrades.Average(), 2);
        }


        // POST: /
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Student student)
        {
            if (!ModelState.IsValid)
            {
                // Remove any empty course entries
                student.Courses = student.Courses
                    .Where(c => !string.IsNullOrWhiteSpace(c.CourseName) && !string.IsNullOrWhiteSpace(c.Grade))
                    .ToList();

                ViewBag.Student = student;
                return View(await _context.Students.Include(s => s.Courses).ToListAsync());
            }


            Console.WriteLine("🟡 Received form submission.");
            Console.WriteLine($"Student: {student.FirstName} {student.LastName}");
            Console.WriteLine($"Courses Count: {student.Courses?.Count}");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("🔴 Model is invalid.");
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine($"Validation Error: {error.ErrorMessage}");
                    }
                }

                return View(student);
            }

            student.Courses = student.Courses
                .Where(c => !string.IsNullOrWhiteSpace(c.CourseName) && !string.IsNullOrWhiteSpace(c.Grade))
                .ToList();
            student.GPA = CalculateGPA(student.Courses);
            Console.WriteLine($"🟢 Saving student: {student.FirstName} with {student.Courses.Count} courses");

            _context.Add(student);
            await _context.SaveChangesAsync();
            Console.WriteLine("✅ Data saved to database.");

            return RedirectToAction(nameof(Index));
        }


    }
}
