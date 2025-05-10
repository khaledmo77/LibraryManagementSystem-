Library Management System
Welcome to the Library Management System project! This system is developed using ASP.NET MVC, Entity Framework Core, and an In-Memory Database to manage books, authors, and borrowing transactions. The application follows the N-Tier Architecture and utilizes the Service Pattern to separate business logic from the controllers. ASP.NET Identity is used for user authentication and authorization, creating distinct layers for users and admins.

This system is built on .NET 9 and provides a robust solution for managing library operations with dynamic book availability and transactions.

Project Overview
The Library Management System allows users to:

Manage books (add, edit, delete, view).

Manage authors (add, edit, delete, view).

Track borrowing and returning books.

Dynamically update book availability based on borrowing status.

Implement user authentication using ASP.NET Identity for managing users and admins.

Core Features:
1. Author Management:
Add, Edit, Delete, and List Authors.

Ensure each author’s full name is unique and follows the required format.

Validate email with unique addresses.

Optional: Website and biography.

A read-only list of books written by the author.

2. Book Management:
Add, Edit, Delete, and List Books.

Each book has:

Title (required).

Genre (selectable from predefined list).

Description (optional, max 300 characters).

Associated author (from dropdown).

3. Book Library:
Lists books with their status (available or borrowed).

Filters based on status, borrow date, and return date.

Borrowing Feature: Allows users to borrow books if available.

Returning Feature: Marks books as available after returning.

4. Borrowing Transactions:
Track the borrowing and returning of books.

Prevent borrowing if a book is already checked out.

Ensure return updates the availability and set correct timestamps.

5. UI/UX Enhancements:
Pagination for books in the library.

Partial Views for dynamic book details and borrowing status.

JavaScript dynamically updates book availability on the borrowing page.

Identity Package for managing user authentication.

Running the Project
Prerequisites
Before running the project, ensure you have the following installed:

.NET SDK 9 or later.

Visual Studio 2022 or later.

SQL Server for production database (in-memory database is used by default).

Setup Instructions
Clone the Repository:

bash
Copy
Edit
git clone https://github.com/khaledmo77/LibraryManagementSystem.git
cd LibraryManagementSystem
Open in Visual Studio:

Open the project folder in Visual Studio.

Restore Dependencies:

Right-click on the solution and select Restore NuGet Packages.

Build the Project:

Press Ctrl + Shift + B to build the solution.

Run the Application:

Press F5 or click the green play button to run the application.

The application should launch at http://localhost:5000.

Database Setup
The system uses Entity Framework Core In-Memory Database by default for testing and development. Sample data for authors and books is seeded automatically when the application starts.

If you'd like to switch to a production database, you can configure SQL Server or any other supported database provider in the appsettings.json file.

N-Tier Architecture Overview
The Library Management System follows the N-Tier Architecture pattern, where different layers handle distinct responsibilities:

1. Presentation Layer (ASP.NET MVC):
Controllers: Handle user requests, interact with services, and return appropriate views.

Views: Display data to the user in an intuitive format using Razor Pages.

2. Business Layer (Services):
Contains all business logic.

Services (e.g., IBorrowingService) perform operations like borrowing and returning books and manage authors and books.

Services interact with the Repository Layer for CRUD operations.

3. Data Layer (Entity Framework Core):
Handles all database operations using Entity Framework Core.

The in-memory database is used by default for simplicity, with seeding functionality for sample data.

4. Dependency Injection:
The application uses Dependency Injection (DI) to decouple components.

Services are injected into controllers, allowing for easier testing and more maintainable code.

Service Pattern
The Service Pattern is used to separate business logic from controllers:

Each service (e.g., IBorrowingService, IAuthorService, IBookService) contains logic related to specific operations.

Controllers only handle HTTP requests and delegate business operations to the services.

This separation promotes clean code, maintainability, and testability.

Identity Package for Authentication and Authorization
The ASP.NET Identity package is used to handle authentication and authorization:

Users can register, log in, and access specific features based on roles (user or admin).

Admins have full control over managing authors and books, while regular users can borrow and return books.

Identity enables user authentication and ensures proper access control between different user roles.

Features and Fixes in Recent Commits
May 10, 2025:

Implemented pagination for book listings to improve navigation.

Fixed issues with the borrowing feature and added full CRUD operations for borrowing transactions.

Enhanced the admin dashboard and improved role management.

Integrated Identity Package for user authentication and role separation.

Refined the navbar for better user navigation.

May 9, 2025:

Added CRUD operations for Books and Authors.

Created edit and details views for authors.

Implemented client-side validation for the create author view.

Used AutoMapper to simplify mapping between view models and data models.

May 8, 2025:

Initialized the project and set up the repository pattern to interact with the in-memory database.

Seeded data for authors and books.

Conclusion
This Library Management System provides an intuitive interface to manage books, authors, and borrowing transactions. Built with .NET 9, Entity Framework Core, and ASP.NET Identity, the system uses N-Tier Architecture and Service Pattern for maintainability and scalability.

Feel free to explore, contribute, or modify the system for your own needs!

For any questions or issues, please raise them on the GitHub repository or contact the development team.
