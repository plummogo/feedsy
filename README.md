 # 📸 feedsy 
Feedsy is a multi-layered .NET + Angular demo application designed to showcase a complete full-stack solution for managing user-generated feeds (text, images, videos). The project follows clean architecture principles, uses RESTful APIs, and emphasizes maintainability, scalability, and best practices.

🚀 Features
- User registration & login with password-based authentication
- Role-based access: users can only manage their own feeds
- Feed types:
  - Text Feed: title, description
  - Image Feed: title, description, image upload
  - Video Feed: title, description, video URL
- CRUD operations for users and feeds
- Like system with like count displayed
- Commenting system under each feed
- Soft delete with scheduled cleanup at midnight
- Integration of external RSS feeds (e.g., via apipheny.io/free-api)
- Swagger API documentation
- Centralized error handling with custom exceptions and error codes
- Logging of all user actions
- Database migrations & seed data included
- Dockerized for easy deployment

🧪 Optional Enhancements
- Responsive Angular frontend
- Modal-based UI for creating/updating/deleting feeds
- Unit tests for business logic
- API integration tests

🛠 Tech Stack
- Backend: ASP.NET Core Web API
- Frontend: Angular
- Database: SQL Server (Entity Framework Core)
- Authentication: JWT
- Logging: Serilog (or similar)
- Docker: Multi-container setup (API + DB)
- Documentation: Swagger / OpenAPI
