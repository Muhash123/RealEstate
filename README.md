# 🏠 RealEstate API — Clean Architecture & CQRS

A modern Web API for managing real estate listings, built using **Clean Architecture** principles and the **CQRS** pattern.

## 🚀 Tech Stack
* **Framework:** .NET 8 Web API
* **Architecture:** Clean Architecture (Domain, Application, Infrastructure, WebApi)
* **Patterns:** CQRS (Command Query Responsibility Segregation)
* **Libraries:** MediatR, Entity Framework Core
* **Database:** SQL Server (LocalDB)
* **API Documentation:** Swagger / OpenAPI

## 🏗 Project Structure
- **Domain**: Core entities (Property) and business logic.
- **Application**: Application logic, interfaces, MediatR Commands, and Queries.
- **Infrastructure**: Data access, migrations, and DbContext implementation.
- **WebApi**: Entry point, Controllers, and Dependency Injection.

## 🛠 How to Run Locally
1. Clone the repository: 
   \git clone https://github.com/Muhash123/RealEstate.git\
2. Restore dependencies:
   \dotnet restore\
3. Update the database:
   \Update-Database -Project RealEstate.Infrastructure -StartupProject RealEstate.WebApi\
4. Run the project (F5).
