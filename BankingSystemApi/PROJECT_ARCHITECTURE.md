# BankingSystemApi - Project Architecture

## 1. Project Overview

BankingSystemApi is an ASP.NET Core Web API project developed using
C#, Entity Framework Core and SQL Server.

The project follows a layered and maintainable structure where each
folder has a clearly defined responsibility.

---

## 2. Folder Responsibilities

### Controllers
Responsible for:
- Receiving HTTP requests
- Calling application services
- Returning HTTP responses

Controllers should not contain business logic.

### DTOs
Responsible for:
- Request models
- Response models
- Preventing direct exposure of database entities

### Models
Contains domain/entity models used by the application.

### Data
Responsible for:
- DbContext
- Database configuration
- Entity Framework Core related operations

### Services
Contains application/business logic.

Structure:

Services/
├── Interfaces/
└── Implementations/

Interfaces define contracts while implementations contain actual logic.

### Validators
Contains request validation logic.

Validation should happen before business logic is executed.

### Filters
Contains reusable MVC filters such as exception handling,
authorization or action filters.

### Middlewares
Contains custom HTTP request pipeline components.

Typical responsibilities:
- Request logging
- Global exception handling
- Correlation IDs
- Request/response processing

### Security
Contains security-related implementations such as:
- JWT
- Password hashing
- Authentication helpers
- Authorization related logic

### Migrations
Contains Entity Framework Core database migrations.

### Program.cs

Application entry point.

Responsible for:
- Service registration
- Dependency Injection
- Middleware pipeline
- Configuration
- Application startup

---

## 3. Request Flow

Client
  ↓
Controller
  ↓
DTO Validation
  ↓
Service Interface
  ↓
Service Implementation
  ↓
DbContext
  ↓
SQL Server
  ↓
Service
  ↓
Controller
  ↓
HTTP Response

---

## 4. Important Rules

1. Controllers should remain thin.
2. Business logic belongs in Services.
3. Database access should be handled through the data layer.
4. DTOs should be preferred over exposing entities directly.
5. Validation should be separated from business logic.
6. Security-related code should remain isolated.
7. Reusable cross-cutting concerns should use Middleware or Filters.
8. Configuration values should not be hard-coded.
9. Database schema changes should be handled through migrations.
10. Dependency Injection should be used instead of manually creating services.

---

## 5. Before Adding a New Feature

For every new feature:

1. Create/update the Entity if required.
2. Create/update EF Core configuration.
3. Create migration if database schema changes.
4. Create Request DTO.
5. Create Response DTO.
6. Create Validator.
7. Create Service Interface.
8. Implement Service.
9. Register dependencies if required.
10. Create Controller endpoint.
11. Test the endpoint.
12. Update documentation if the feature changes architecture.

---

## 6. Production Readiness Checklist

- [ ] Global exception handling
- [ ] Request logging
- [ ] Input validation
- [ ] Authentication
- [ ] Authorization
- [ ] JWT configuration
- [ ] Secure password hashing
- [ ] DTO-based API contracts
- [ ] Database migrations
- [ ] Environment-based configuration
- [ ] Proper HTTP status codes
- [ ] API documentation
- [ ] Unit tests
- [ ] Integration tests
- [ ] Health checks
- [ ] Structured logging
- [ ] API versioning where required

---

## 7. Goal

The objective of this structure is to make the application:

- Maintainable
- Testable
- Scalable
- Easy to understand
- Easy for new developers to contribute to
- Reusable as a template for future ASP.NET Core projects