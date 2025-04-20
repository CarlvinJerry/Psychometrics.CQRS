# Psychometrics CQRS API

A .NET 8.0 API implementing CQRS (Command Query Responsibility Segregation) pattern for psychometric testing.

## Features

- CQRS pattern implementation
- Clean Architecture
- Entity Framework Core
- MediatR for handling commands and queries
- AutoMapper for object mapping
- Swagger/OpenAPI documentation

## Project Structure

- **Psychometrics.Api**: Web API project
- **Psychometrics.Application**: Application layer with commands, queries, and interfaces
- **Psychometrics.Domain**: Domain layer with entities and business logic
- **Psychometrics.Infrastructure**: Infrastructure layer with database context and implementations

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- SQL Server (LocalDB or full instance)

### Running the Application

1. Clone the repository
2. Navigate to the API project directory:
   ```
   cd Psychometrics.Api
   ```
3. Run the application:
   ```
   dotnet run
   ```
4. Access the Swagger UI at: https://localhost:5001/swagger

## API Endpoints

### Students
- POST /api/students - Create a new student
- GET /api/students/{id} - Get student by ID

### Responses
- POST /api/responses - Create a new response
- GET /api/responses/{id} - Get response by ID

## Author

CarlvinJerry 