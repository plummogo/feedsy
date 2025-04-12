Development steps:

1. dotnet new webapi -n FeedsyAPI
2. dotnet dev-certs https --trust
3. dotnet new xunit -n FeedsyAPI.Tests
4. global.json > for locking the .net sdk version
5. dotnet add package Swashbuckle.AspNetCore
6. Implemented Swagger middleware in Startup.cs
7. dotnet new apicontroller --name AuthController --output .\FeedsyAPI\Controllers
8. dotnet run --project .\FeedsyAPI
9. Start-Process "http://localhost:8080/swagger"
10. dotnet add c:\Users\szilv\Documents\_repos\feedsy\feedsy\FeedsyAPI.Tests\ControllerTest.cs reference c:\Users\szilv\Documents\_repos\feedsy\feedsy\FeedsyAPI\FeedsyAPI.csproj
11. dotnet add c:\Users\szilv\Documents\_repos\feedsy\feedsy\FeedsyAPI.Tests\FeedsyAPI.Tests.csproj package Microsoft.AspNetCore.Mvc.Core
12. dotnet test
13. cd c:\Users\{USER}\_repos\feedsy\feedsy dotnet new classlib -n FeedsyAPI.Models
14. dotnet add FeedsyAPI.Tests\FeedsyAPI.Tests.csproj reference FeedsyAPI.Models\FeedsyAPI.Models.csproj
15. docker compose up --build
16. dotnet new console -n FeedsyAPI.Data
17. dotnet add package Microsoft.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer  # Ha SQL Server-t használsz
    dotnet add package Microsoft.EntityFrameworkCore.Tools
18. dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
19. dotnet ef migrations add InitialCreate --project FeedsyAPI.Data --startup-project FeedsyAPI
20. dotnet ef database update --project FeedsyAPI.Data --startup-project FeedsyAPI 