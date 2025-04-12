using FeedsyAPI.Controllers;
using FeedsyAPI.Models;
using FeedsyAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FeedsyAPI.Tests;

public class AuthControllerTest
{
    private readonly Mock<IAuthService> _userServiceMock;
    private readonly AuthController _controller;

    public AuthControllerTest()
    {
        _userServiceMock = new Mock<IAuthService>();
        _controller = new AuthController(_userServiceMock.Object);
    }

    [Fact]
    public async Task GetUserById_ReturnsNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        var userId = "nonexistentId";
        _userServiceMock.Setup(s => s.GetUserByIdAsync(userId)).ReturnsAsync((User)null);

        // Act
        var result = await _controller.GetUserById(userId);

        // Assert
        var notFoundResult = Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public async Task GetUserById_ReturnsOk_WhenUserExists()
    {
        // Arrange
        var userId = "existingId";
        var user = new User { Id = userId, UserName = "TestUser" };
        _userServiceMock.Setup(s => s.GetUserByIdAsync(userId)).ReturnsAsync(user);

        // Act
        var result = await _controller.GetUserById(userId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnUser = Assert.IsType<User>(okResult.Value);
        Assert.Equal(userId, returnUser.Id);
    }

    [Fact]
    public async Task GetAllUsers_ReturnsOk_WhenUsersExist()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Id = "1", UserName = "User1" },
            new User { Id = "2", UserName = "User2" }
        };
        _userServiceMock.Setup(s => s.GetAllUsersAsync()).ReturnsAsync(users);

        // Act
        var result = await _controller.GetAllUsers();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnUsers = Assert.IsAssignableFrom<IEnumerable<User>>(okResult.Value);
        Assert.Equal(2, returnUsers.Count());
    }

    [Fact]
    public async Task CreateUser_ReturnsCreatedAtAction_WhenUserIsCreated()
    {
        // Arrange
        var user = new User { Id = "newId", UserName = "NewUser" };
        _userServiceMock.Setup(s => s.CreateUserAsync(user)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.CreateUser(user);

        // Assert
        var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
        Assert.Equal("GetUserById", createdAtActionResult.ActionName);
        Assert.Equal(user.Id, createdAtActionResult.RouteValues["id"]);
    }

    [Fact]
    public async Task UpdateUser_ReturnsNoContent_WhenUserIsUpdated()
    {
        // Arrange
        var user = new User { Id = "existingId", UserName = "UpdatedUser" };
        _userServiceMock.Setup(s => s.UpdateUserAsync(user)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.UpdateUser(user.Id, user);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }

    [Fact]
    public async Task DeleteUser_ReturnsNoContent_WhenUserIsDeleted()
    {
        // Arrange
        var userId = "existingId";
        _userServiceMock.Setup(s => s.DeleteUserAsync(userId)).Returns(Task.CompletedTask);

        // Act
        var result = await _controller.DeleteUser(userId);

        // Assert
        Assert.IsType<NoContentResult>(result);
    }
}
