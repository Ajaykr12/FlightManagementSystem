# FlightManagementSystem

An ASP.NET Core MVC application to track expenses, categorize them,
and generate summaries. This project is designed for learning purposes
and can also be used as a basic template for personal expense
tracking.

# Features
 1.Designed and implemented features for seat reservation,
 cancellation, and real-time reservation status tracking, enabling
 seamless booking experiences for passengers.
 2.Developed robust admin tools for updating flight schedules and
 generating detailed reports, including reservation charts and
 flight schedules, ensuring operational efficiency.
 3.Integrated user authentication with role-based access for
 administrators and users, providing secure login, personalized
 dashboards, and intuitive views for managing flight schedules
 and reservations.

# Prerequisites
Before setting up this project, ensure you have the following
installed on your machine:
1. **NET SDK (6.0 or later)**
   [Download .NET](https://dotnet.microsoft.com/download)
2. **SQL Server (Express or Developer Edition recommended)**
   [Download SQL
Server](https://www.microsoft.com/en-in/sql-server/sql-server-downloads)
3. **Visual Studio 2022 (or later) with ASP.NET and web development workload.**
   [Download Visual Studio](https://visualstudio.microsoft.com/)

# Getting Started
Follow these steps to set up and run the project on your machine:
1. **Clone the Repository**
      1. git clone https://github.com/Ajaykr12/FlightManagementSystem.git
      2. cd expense-tracker
2. **Set Up the Database**
      1. Open **SQL Server Management Studio (SSMS)** or a similar SQL
Server client.
      2. Create a new database named ExpenseTrackerDb.
      3. Update the **connection string** in **appsettings.json** if necessary:
       "ConnectionStrings": {
          "DefaultConnection":
"Server=YOUR_SERVER_NAME;Database=ExpenseTrackerDb;Integrated
            Security=True;MultipleActiveResultSets=True;"
           }
      4. Replace YOUR_SERVER_NAME with your SQL Server instance name.
      5. If you are using SQL Authentication, replace Integrated
Security=True with User ID=your-username;Password=your-
          password;.
3. **Install below Entity Framework from Nuget Package Manager**
      1. Microsoft.EntityFrameworkCore
      2. Microsoft.EntityFrameworkCore.Tools
      3. Microsoft.EntityFrameworkCore.SqlServer
4. **Apply Migrations(It will create the necessary tables in the database)**
     1. Add-Migration "InitialCreate"
     2. Update-database
5. **Build and Run the Application**
      1. Open the project in **Visual Studio**.
      2. Press **F5** to run the application.
      3. Alternatively, use the .NET CLI:
            1. dotnet build
            2. dotnet run
6. **Usage Instructions**
         1. **Expenses** Navigate to the "Expenses" page to view all
recorded expenses.
         2. **Add Expense** Use the "Add Expense" link in the navbar
to record a new expense.
         3. **Summary** Click on the "Summary" link to view expense
summaries by category.

7. **Folder Structure**
          1. **Controllers**: Handles the request and response logic.
          2. **Models**: Defines the database schema and business logic.
          3. **Views**: Contains Razor pages for the UI.
          4. **wwwroot**: Static files like CSS, JavaScript, and images.

8. **Technologies Used**
        1. ASP.NET Core MVC
        2. Entity Framework Core
        3. SQL Server
        4. Bootstrap (for styling)

9. **Contribution**
         1. Feel free to fork this repository, make changes, and
submit a pull request. Contributions are welcome!

10. **License**
      1. This project is licensed under the MIT License. You are free
to use, modify, and distribute this project as per the license terms.

11. **Troubleshooting**
       1. Verify your SQL Server instance is running.
       2. Ensure the database connection string is correctly
configured in appsettings.json.
       3. Check for missing NuGet packages and restore them using
Visual Studio or dotnet restore.
       4. Run dotnet ef database update again if the database tables
are missing.
12. **Contact**
      1. **Email**: akajaykkumar2@gmail.com
      2. **Linkedlin**: [Ajay Kumar](https://www.linkedin.com/in/ajay-singh-rajput-b5186b95)
