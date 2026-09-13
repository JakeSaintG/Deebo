using HomeManager.Server.Models;
using HomeManager.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    [SwaggerOperation("Add a user")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request)
    {
        var user = await _userService.CreateUserAsync(request.Name, request.Email);
        return Ok(user);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get a user by id")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet]
    [SwaggerOperation("Get all users")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Make updates to a user by id")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserRequest request)
    {
        var user = await _userService.UpdateUserAsync(id, request.Name, request.Email);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Delete a user by a given id")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var success = await _userService.DeleteUserAsync(id);
        if (!success)
        {
            return NotFound();
        }
        return NoContent();
    }
}

// Request models
public class CreateUserRequest: IUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}

public class UpdateUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}
