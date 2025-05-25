# Cinema-Time

Cinema-Time is a modular web application that allows users to view upcoming movies and reserve seats for showings. The project uses a Blazor frontend, a Web API backend built with ASP.NET Core, and a SQLite database. It follows clean architecture principles, with separate projects for Core logic, Infrastructure, API, and testing.

-----------

## ▶️ Running the Application

1. Open a terminal and navigate to the `Cinema.WebApi` folder for running trhe Web API:

   ```bash
   cd Cinema.WebApi
   dotnet run
   ```

2. Open another terminal and navigate to the `Cinema.Blazor` folder for running the Blazor frontend:

   ```bash
   cd Cinema.Blazor
   dotnet run
   ```

-----------

## ✨ Features

* View a list of upcoming movies
* Reserve seats for specific showings
* Administer salons, reservations, and movies
* Integration with SQLite (or in-memory DB for testing)
* API documented via Swagger
* Unit and integration testing

-----------

## 📂 Project Structure

```
Cinema-Time/
│
├── Cinema.Blazor/            # Blazor WebAssembly frontend
├── Cinema.Core/              # Domain models and interfaces
├── Cinema.Infrastructure/    # Database setup, repositories (SQLite/EF Core)
├── Cinema.WebApi/            # ASP.NET Core Web API
├── Cinema.IntegrationTests/  # Integration tests (xUnit)
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

## Architecture Overview

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


