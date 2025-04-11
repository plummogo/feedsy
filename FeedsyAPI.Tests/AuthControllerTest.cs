using FeedsyAPI.Controllers;
using FeedsyAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FeedsyAPI.Tests;

public class AuthControllerTest
{
    [Fact]
    public void Test_AuthController_Register_Returns_Ok()
    {
        // Arrange
        var controller = new AuthController(); // Ensure AuthController exists in FeedsyAPI.Controllers
        var mockRequest = new RegisterRequest { Email = "testmail@mail.com", Password = "testpassword", Username = "testuser" };

        // Act
        var result = controller.Register(mockRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    
    [Fact]
    public void Test_AuthController_Login_Returns_Ok()
    {
        // Arrange
        var controller = new AuthController(); // Ensure AuthController exists in FeedsyAPI.Controllers
        var mockRequest = new LoginRequest { Username = "testuser", Password = "testpassword" };

        // Act
        var result = controller.Login(mockRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }

    [Fact]
    public void Test_AuthController_Me_Returns_Ok()
    {
        // Arrange
        var controller = new AuthController(); // Ensure AuthController exists in FeedsyAPI.Controllers

        // Act
        var result = controller.Me();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.NotNull(okResult.Value);
    }
}
