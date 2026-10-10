# Vehicle Leasing Management System

## Overview
A comprehensive ASP.NET MVC application for managing vehicle leasing operations. This system allows companies to track vehicle procurement, allocation, leasing, and driver assignments.

## Features
- **Vehicle Management**: Complete CRUD operations for vehicle fleet
- **Supplier Management**: Track vehicle suppliers and procurement sources
- **Branch Management**: Manage branch locations and vehicle allocations
- **Client Management**: Handle client companies and leasing agreements
- **Driver Management**: Track driver information and assignments
- **Dashboard Reporting**: Real-time statistics and analytics
- **Modern UI**: Clean, responsive design with professional styling

## Technology Stack
- **Framework**: ASP.NET MVC (.NET Framework)
- **Database**: Microsoft SQL Server with Entity Framework Code-First
- **Frontend**: HTML5, CSS3, JavaScript, Bootstrap
- **Language**: C#

## Database Schema
The application uses the following entities:
- **Vehicles**: Core entity with vehicle details and relationships
- **Suppliers**: Vehicle procurement sources
- **Branches**: Branch locations for vehicle allocation
- **Clients**: Companies that lease vehicles
- **Drivers**: Vehicle operators and drivers

## Installation & Setup
1. **Clone the repository**
   ```
   git clone https://github.com/JNR-Sasim/-VehicleLeasingManagementSystem.git
   ```
2. **Open the solution** (`VehicleLeasingApp.sln`) in Visual Studio.
3. **Restore NuGet packages** (Visual Studio usually does this automatically on first build; otherwise right-click the solution → Restore NuGet Packages).
4. **(Optional) Update the connection string** in `Web.config`.
   - The project ships configured for **SQL Server LocalDB** (`(LocalDb)\MSSQLLocalDB`), which installs with Visual Studio's "ASP.NET and web development" workload. If you have that, **no change is needed** — skip this step.
   - Only edit the connection string if you want to use a different database, e.g. a full SQL Server instance:
     ```
     Data Source=YOUR_SERVER;Initial Catalog=VehicleLeasingDB;Integrated Security=True
     ```
5. **Run the application** — press `F5` (or `Ctrl+F5`). On first run, Entity Framework Code-First automatically creates the `VehicleLeasingDB` database, builds all tables, and seeds sample data, so the dashboard loads already populated.

> Optional: a `VehicleLeasingDB.bak` backup is included. If you prefer, restore it in SQL Server Management Studio and point the connection string at that database instead of using the auto-created one.

## Usage
- Navigate to the dashboard for fleet overview statistics and analytics.
- Use the top navigation bar to switch between modules (Vehicles, Suppliers, Branches, Clients, Drivers).
- Each module provides full CRUD operations (view, create, edit, delete).

## Requirements
- Windows
- Visual Studio 2019 or later (with the "ASP.NET and web development" workload)
- .NET Framework 4.7.2 or later
- SQL Server LocalDB (included with Visual Studio) — or SQL Server 2016+ if you prefer a full instance

## Contact
For verification and questions, contact: jsimelane3@gmail.com