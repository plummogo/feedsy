# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /app

# Copy sln and csproj files first (for cache efficiency)
COPY FeedsyAPI/FeedsyAPI.csproj FeedsyAPI/
COPY FeedsyAPI.Models/FeedsyAPI.Models.csproj FeedsyAPI.Models/
COPY FeedsyAPI.Tests/FeedsyAPI.Tests.csproj FeedsyAPI.Tests/
COPY FeedsyAPI.Services/FeedsyAPI.Services.csproj FeedsyAPI.Services/
COPY feedsy.sln .

# Restore dependencies
RUN dotnet restore

# Copy the rest of the code
COPY . .

# Build and publish
WORKDIR ./FeedsyAPI
RUN dotnet publish -c Release -o /app/publish

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /feedsy
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "FeedsyAPI.dll"]