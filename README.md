# Library Management System

Welcome to the **Library Management System** project! This system is built with **ASP.NET MVC**, **Entity Framework Core**, and an **In-Memory Database** to efficiently manage books, authors, and borrowing transactions. The system follows **N-Tier Architecture** with the **Service Pattern** to separate business logic from controllers. **ASP.NET Identity** is implemented for secure user authentication and authorization.

Built on **.NET 9**, this application provides a scalable and robust solution for managing library operations, including dynamic book availability and transaction management.

## Project Overview

The **Library Management System** provides a user-friendly platform to:

- **Manage Books**: Add, edit, delete, and view books
- **Manage Authors**: Add, edit, delete, and view authors
- **Track Borrowing and Returning**: Manage the borrowing process and track book returns
- **Dynamic Book Availability**: Update book availability in real-time based on borrowing status
- **User Authentication**: Leverage **ASP.NET Identity** for user and admin roles

## Core Features

### Author Management
- Add, Edit, Delete, and List Authors
- Ensure each author's full name is unique
- **Email Validation**: Enforce unique email addresses
- Optional fields: Website and Biography
- View books written by each author

### Book Management
- Add, Edit, Delete, and List Books
- Required book details:
  - Title
  - Genre (selectable from a predefined list)
  - Description (optional, max 300 characters)
  - Associated Author (selected from a dropdown)

### Book Library
- View a list of books with their status (available or borrowed)
- Filter by book status, borrow date, and return date

### Borrowing Feature
- Borrow available books

### Returning Feature
- Mark books as available upon return

### Borrowing Transactions
- Track borrowing and returning of books
- Prevent borrowing a book that is already checked out

### Availability Update
- Ensure the book status is correctly updated on return

## UI/UX Enhancements
- **Pagination** for improved navigation
- **Partial Views** for dynamic updates on book details and borrowing status
- **JavaScript** to dynamically update book availability when borrowing or returning books

## ASP.NET Identity for Authentication
- Manage secure user authentication and authorization

## Running the Project

### Prerequisites
Ensure you have the following installed:

- **.NET SDK 9** or later
- **Visual Studio 2022** or later
- **SQL Server** (for production database; in-memory database is used by default)

### Setup Instructions

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/khaledmo77/LibraryManagementSystem.git
   cd LibraryManagementSystem
## Getting Started

### Open in Visual Studio:
- Open the project folder in Visual Studio

### Restore Dependencies:
- Right-click on the solution in Visual Studio and select "Restore NuGet Packages"

### Build the Project:
- Press `Ctrl + Shift + B` to build the solution

### Run the Application:
- Press `F5` or click the green play button to run the application
- The application should launch at `http://localhost:5000`

## Database Setup
- By default, the system uses Entity Framework Core In-Memory Database for testing and development
- Sample data for authors and books is seeded automatically at startup
- For production use, configure a SQL Server or other supported database provider in the `appsettings.json` file

## Architecture and Design Patterns

### N-Tier Architecture Overview
The Library Management System follows the N-Tier Architecture pattern, which separates the application into distinct layers:

**Presentation Layer (ASP.NET MVC):**
- Controllers: Handle user requests, interact with services, and return appropriate views
- Views: Display data to users using Razor Pages

**Business Layer (Services):**
- Contains the core business logic (e.g., borrowing books, managing authors, and books)
- Services (e.g., `IBorrowingService`, `IAuthorService`, `IBookService`) interact with the Repository Layer to perform CRUD operations

**Data Layer (Entity Framework Core):**
- Handles all database operations using Entity Framework Core
- The in-memory database is used for simplicity, with data seeding functionality

### Dependency Injection
- Used to decouple components
- Services are injected into controllers, making the code more maintainable and easier to test

### Service Pattern
- Employed to separate business logic from controllers
- Each service (e.g., `IBorrowingService`, `IAuthorService`, `IBookService`) contains the relevant logic for specific operations
- Controllers delegate business operations to these services, improving maintainability and promoting clean, testable code

### Identity Package for Authentication and Authorization
- ASP.NET Identity manages user authentication and authorization
- Users can register, log in, and access certain features based on their roles (user or admin)
- Admins have full control over managing authors and books
- Regular users can borrow and return books
- Ensures proper access control between different user roles

## Development History

### Recent Features and Fixes

#### May 10, 2025:
- Implemented pagination for book listings for easier navigation
- Fixed issues with the borrowing feature and added full CRUD operations for borrowing transactions
- Enhanced admin dashboard and improved role-based management
- Integrated Identity Package for secure user authentication and role separation
- Refined navbar for better user experience

#### May 9, 2025:
- Added CRUD operations for books and authors
- Created edit and details views for authors
- Implemented client-side validation for creating authors
- Used AutoMapper to simplify mapping between view models and data models

#### May 8, 2025:
- Initialized the project and set up the repository pattern for interacting with the database


Key improvements made:
1. **Logical Grouping**: Related sections are now grouped together under appropriate headers
2. **Consistent Formatting**: All sections follow the same markdown styling
3. **Better Hierarchy**: Added sub-sections under "Architecture and Design Patterns"
4. **Improved Readability**: Clear separation between different types of information
5. **Maintained Flow**: Technical details are organized from setup to architecture to development history

The separation was done to:
- Prevent information overload
- Make it easier to find specific information
- Create a natural reading flow from installation to architecture to development details
- Group related concepts together for better understanding
