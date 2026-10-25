using HomeManager.Server.Models;
using HomeManager.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

// TODO: Need to think through "private" endpoints vs "public" endpoints
// Many of these log endpoints shouldn't be "public" or exposed on Swagger

[ApiController]
[Route("api/[controller]")]
public class LogController : ControllerBase
{
    private readonly LogService _logService;

    public LogController(LogService logService)
    {
        _logService = logService;
    }

    [HttpPost]
    [SwaggerOperation("Add log entry")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "Request successful", typeof(LogEntry))]
    public async Task<IActionResult> CreateLogEntry([FromBody] CreateLogRequestFromBody request)
    {
        var user = await _logService.CreateLogEntryAsync(
            request.Id,
            request.Name,
            request.LogLevel,
            request.LogSource,
            request.LogDTS,
            request.LogMessage
        );

        return Ok(user);
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Get log entry by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(LogEntry))]
    public async Task<IActionResult> GetLogEntry(Guid id)
    {
        var logEntry = await _logService.GetLogEntryByIdAsync(id);
        if (logEntry == null)
        {
            return NotFound();
        }
        return Ok(logEntry);
    }

    // TODO: a controller for the discord bot to pull logs, send them to Discord, and then ack
    // - ack one at a time
    // - ack in batch? Maybe?

    // TODO: Okay for now but should be paginated
    [HttpGet]
    [SwaggerOperation("Get all log entries")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(LogEntry[]))]
    public async Task<IActionResult> GetAllUsers()
    {
        var logEntriess = await _logService.GetAllLogEntriesAsync();
        return Ok(logEntriess);
    }

    [HttpPut("{id}")]
    [SwaggerOperation("Ack log by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(LogEntry))]
    [SwaggerResponse(404, "Request not found")]
    public async Task<IActionResult> AckLogEntry(Guid id, [FromBody] UpdateLogRequestFromBody request)
    {
        var logEntry = await _logService.AckLogEntryAsync(id, request.Consumed);
        if (logEntry == null)
        {
            return NotFound();
        }
        return Ok(logEntry);
    }

    // NO DELETE METHOD (No endpoint for Log Compression. Should be done internally)
}

// Request models
public class CreateLogRequestFromBody: ILogEntry
{
    public Guid? Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    // TODO: Maybe use a timestamp type?
    public required string LogDTS { get; set; }
    public string? LogMessage { get; set; }
}

// TODO: This really only should be for acking
// Need to think of a log compression/retention but that shouldn't be an endpoint
public class UpdateLogRequestFromBody: ILogEntry
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required string LogLevel { get; set; }
    public required string LogSource { get; set; }
    
    // TODO: Maybe use a timestamp type?
    public required string LogDTS { get; set; }
    public string? LogMessage { get; set; }

    public bool Consumed { get; set; }
}
