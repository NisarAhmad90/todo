# Fullstack ToDo App with Clean Archit

##  Technologies Used

- **Frontend**: ReactJS + TypeScript + Bootstrap 5  
- **Backend**: ASP.NET Core (.NET 8)  
- **Architecture**: Clean Architecture  
- **Database**: SQLite (EF Core)  
- **IDE**: Visual Studio 2022 and vs code

## Project Structure

TTodoApp/
├── TodoApp.sln
├── TodoApp.API/
├── TodoApp.Application/
├── TodoApp.Domain/
├── TodoApp.Infrastructure/
└── todoapp-client/

## Setup Instructions

### Backend

1. Open `TodoApp.sln` in Visual Studio 2022.
2. Run EF Core migrations:

   ```bash
   Add-Migration InitialCreate -Project TodoApp.Infrastructure -StartupProject TodoApp.API
   Update-Database -Project TodoApp.Infrastructure -StartupProject TodoApp.API
3. Start the API project (TodoApp.API).

## Features
Add, , delete, toggle ToDo tasks

Tasks are highlighted in red if overdue
Enforced business rule: Title must be > 10 characters
Clean Architecture separation between layers

Designed and developed by Your Nisar Ahmad
