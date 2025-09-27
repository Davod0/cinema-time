# Cinema-Time

Cinema-Time is a modular web application where I demonstrate my skills
in understanding and implementing a full-stack solution with .NET technologies.

This solution is organized into multiple projects that together form Cinema-Time.
The Blazor frontend communicates with the ASP.NET Core Web API, while the Core project defines business logic and the Infrastructure layer (SQLite/EF Core) handles data persistence.
The system is supported by both unit tests and integration tests to ensure reliability and maintainability.
The application allows users to view upcoming movies and reserve seats for showings.

The project uses a Blazor frontend, a Web API built with ASP.NET Core, and a SQLite database.
For unit testing, xUnit and Moq are used, while integration tests are implemented with Microsoft.AspNetCore.Mvc.Testing and utilize an in-memory database.
It follows clean architecture principles with separate projects for Core logic, Infrastructure, API, and testing.

There is also an admin interface for this project for managing salons, reservations, movies and screenings built on Next.js.

## ▶️ Running the Application

1. Open a terminal and navigate to the `Cinema.WebApi` folder for running the Web API:

   ```bash
   cd Cinema.WebApi
   dotnet run
   ```

2. Open another terminal and navigate to the `Cinema.Blazor` folder for running the Blazor frontend:

   ```bash
   cd Cinema.Blazor
   dotnet run
   ```


## ▶️ Running the tests

1. Open a terminal and navigate to the `Cinema.Test` folder for running the unit tests:

   ```bash
   cd Cinema.Test
   dotnet test
   ```

2. Open another terminal and navigate to the `Cinema.IntegrationTests` folder for running the integration tests:

   ```bash
   cd Cinema.IntegrationTests
   dotnet test
   ```

## ✨ Features

* View a list of upcoming movies
* Reserve seats for specific showings
* Managing salons, reservations, movies and screenings through the API.
* API documented via Swagger
* Unit and integration testing

-----------

## 📂 Project Structure

```
Cinema-Time/
│
├── Cinema.Blazor/            # Blazor frontend
├── Cinema.Core/              # Domain models and interfaces, services (business logic)
├── Cinema.Infrastructure/    # Database setup, repositories (SQLite/EF)
├── Cinema.WebApi/            # ASP.NET Core Web API
├── Cinema.IntegrationTests/  # Integration tests (xUnit, Microsoft.AspNetCore.Mvc.Testing)
├── Cinema.Test/              # Unit tests (xUnit, Moq)
```


## Blazor Client Architecture (Component to Database)


      ┌────────────────────┐
      │   Blazor-component │    ← Frontend
      └────────────────────┘
             │
             ▼
      ┌────────────────────┐
      │   SalonService     │    ← Service-layer
      └────────────────────┘
             │
             ▼
┌────────────────────────────┐
│     ISalonRepository       │    ← Interface (Abstraktion)
└────────────────────────────┘
             │
             ▼
┌────────────────────────────┐
│    EFSalonRepository       │    ← Implementing of Entity Framework
│     (uses DbContext)       │
└────────────────────────────┘
             │
             ▼
      Databas (SQL Server, etc.)


-----------

## API Architecture (From HTTP Request to Database)

[HTTP Request]
     │
     ▼
[🎮 Controller]
     │
     ▼
[🧠 Service Class]
     │
     ▼
[📦 EFRepository ]
     │
     ▼
[🗄️ Database]




## 🔧 Technologies Used

* ASP.NET Core 8
* Blazor
* Entity Framework Core (with SQLite & InMemory)
* xUnit 
* Swagger (Swashbuckle)


