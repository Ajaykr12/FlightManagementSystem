# FlightManagementSystem
An ASP.NET Core MVC application to track expenses, categorize them,
and generate summaries. This project is designed for learning purposes
and can also be used as a basic template for personal expense
tracking.

Features
Designed and implemented features for seat reservation,
cancellation, and real-time reservation status tracking, enabling
seamless booking experiences for passengers.
Developed robust admin tools for updating flight schedules and
generating detailed reports, including reservation charts and
flight schedules, ensuring operational efficiency.
Integrated user authentication with role-based access for
administrators and users, providing secure login, personalized
dashboards, and intuitive views for managing flight schedules
and reservations.
Before setting up this project, ensure you have the following
installed on your machine:

NET SDK (6.0 or later) Download .NET
SQL Server (Express or Developer Edition recommended) Download SQL Server
Visual Studio 2022 (or later) with ASP.NET and web development
workload. Download Visual Studio
Getting Started
Follow these steps to set up and run the project on your machine:

Clone the Repository

git clone https://github.com/Ajaykr12/FlightManagementSystem.git
cd FlightManagementSystem
Set Up the Database

Open SQL Server Management Studio (SSMS) or a similar SQL Server client.
Create a new database named ExpenseTrackerDb.
Update the connection string in appsettings.json if necessary:
"ConnectionStrings": { "DefaultConnection":
"Server=YOUR_SERVER_NAME;Database=ExpenseTrackerDb;Integrated
Security=True;MultipleActiveResultSets=True;" }
Replace YOUR_SERVER_NAME with your SQL Server instance name.
If you are using SQL Authentication, replace Integrated Security=True
with User ID=your-username;Password=your-password;.
Install below Entity Framework from Nuget Package Manager

Microsoft.EntityFrameworkCore
Microsoft.EntityFrameworkCore.Tools
Microsoft.EntityFrameworkCore.SqlServer
Apply Migrations(It will create the necessary tables in the database)

Add-Migration "InitialCreate"
Update-database
Build and Run the Application

Open the project in Visual Studio.
Press F5 to run the application.
Alternatively, use the .NET CLI:
dotnet build
dotnet run
Usage Instructions 1. Expenses Navigate to the "Expenses" page to view
all recorded expenses. 2. Add Expense Use the "Add Expense" link in
the navbar to record a new expense. 3. Summary Click on the "Summary"
link to view expense summaries by category.

Folder Structure 1. Controllers: Handles the request and response
logic. 2. Models: Defines the database schema and business logic. 3.
Views: Contains Razor pages for the UI. 4. wwwroot: Static files like
CSS, JavaScript, and images.

Technologies Used 1. ASP.NET Core MVC 2. Entity Framework Core 3. SQL
Server 4. Bootstrap (for styling)

Contribution 1. Feel free to fork this repository, make changes, and
submit a pull request. Contributions are welcome!

License

This project is licensed under the MIT License. You are free to use,
modify, and distribute this project as per the license terms.
Troubleshooting

Verify your SQL Server instance is running.
Ensure the database connection string is correctly configured in
appsettings.json.
Check for missing NuGet packages and restore them using Visual Studio
or dotnet restore.
Run dotnet ef database update again if the database tables are missing.
Contact

Email: akajaykkumar2@gmail.com
