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
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "Request successful", typeof(User))]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequestFromBody request)
    {
        var user = await _userService.CreateUserAsync(request.Name, request.Email);
        return Ok(user);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get a user by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User))]
    public async Task<IActionResult> GetUser(Guid id)
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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User[]))]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Make updates to a user by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User))]
    [SwaggerResponse(404, "Request not found")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UpdateUserRequesFromBody request)
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
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [SwaggerResponse(204, "Request successful")]
    [SwaggerResponse(404, "Request not found")]
    public async Task<IActionResult> DeleteUser(Guid id)
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
public class CreateUserRequestFromBody: IUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}

public class UpdateUserRequesFromBody: IUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}
