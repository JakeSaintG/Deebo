using HomeManager.Server.Models;
using HomeManager.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly LogService _logService;

    public LogController(UserService logService)
    {
        _logService = logService;
    }

    [HttpPost]
    [SwaggerOperation("Add log entry")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "Request successful", typeof(User))]
    public async Task<IActionResult> CreateUser([FromBody] CreateLogRequestFromBody request)
    {
        var user = await _logService.CreateUserAsync(request.Name, request.Email);
        return Ok(user);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get log entry by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User))]
    public async Task<IActionResult> GetLogEntry(Guid id)
    {
        var logEntry = await _logService.GetUserByIdAsync(id);
        if (logEntry == null)
        {
            return NotFound();
        }
        return Ok(logEntry);
    }

    // TODO: Okay for now but should be paginated
    [HttpGet]
    [SwaggerOperation("Get all log entries")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User[]))]
    public async Task<IActionResult> GetAllUsers()
    {
        var logEntriess = await _logService.GetAllUsersAsync();
        return Ok(logEntriess);
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Ack log by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User))]
    [SwaggerResponse(404, "Request not found")]
    public async Task<IActionResult> AckLogEntry(Guid id, [FromBody] UpdatLogRequestFromBody request)
    {
        // TODO: Only ack/queue 
        
        var logEntry = await _logService.UpdateUserAsync(id, request.Name, request.Email);
        if (logEntry == null)
        {
            return NotFound();
        }
        return Ok(logEntry);
    }

    // NO DELETE METHOD (maybe do one later? Log Compression?)
}

// Request models
public class CreateLogRequestFromBody: IUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}

public class UpdatLogRequestFromBody: IUserRequest
{
    public required string Name { get; set; }
    public string? Email { get; set; }
}
