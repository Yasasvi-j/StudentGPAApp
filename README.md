# Student GPA App

An ASP.NET Core MVC web application that allows users to enter student names and a dynamic list of course grades. The app calculates each student's GPA and stores all data in a local SQLite database. Users can also view all submitted data on a separate tab.

---

## 🧠 Features

- 🧾 Input Form on Homepage:
  - Enter student first/last name
  - Add/remove any number of course-grade pairs
  - Drop-down menus for course names and grades

- 📊 GPA Calculation:
  - GPA is computed based on grade values (A=4.0, B=3.0, etc.)
  - GPA is stored in the database and displayed to the user

- 🗂 View Data Tab:
  - Displays a table with all student names, courses, grades, and GPA

- ✅ Form Validation:
  - Inline errors when any required field is missing

- 🎨 Styling:
  - Custom CSS provides a clean, modern layout

---

## 📁 Project Structure

```bash
StudentGPAApp/
├── Controllers/
│   └── HomeController.cs
├── Models/
│   ├── Student.cs
│   └── CourseGrade.cs
├── Views/
│   ├── Home/
│   │   ├── Index.cshtml
│   │   └── ViewData.cshtml
│   └── Shared/
│       ├── _Layout.cshtml
│       └── _ValidationScriptsPartial.cshtml
├── wwwroot/
│   └── css/
│       ├── index.css
│       └── viewdata.css
├── appsettings.json
├── appsettings.Development.json
├── Program.cs
├── Startup.cs
└── README.md



## 🚀 How to Run Locally

Follow these steps to set up and run the application on your local machine.

### 🧰 Prerequisites

- [.NET 7.0 SDK or later](https://dotnet.microsoft.com/en-us/download)
- (Optional) Visual Studio or Visual Studio Code
- Git (for cloning the repository)

### 🛠 Steps

1. **Clone the repository:**

   ```bash
   git clone https://github.com/YOUR_USERNAME/StudentGPAApp.git
   cd StudentGPAApp
   

2. **Restore dependencies:**
```dotnet restore
   
3. **Build the project**
```dotnet build
    
4. **Apply database migrations:**
This sets up the local SQLite database schema.
```dotnet ef database update

5. **Run the application:**
```dotnet run

By default, the app will be available at: http://localhost:5156



