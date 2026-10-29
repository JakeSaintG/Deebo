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
    [SwaggerOperation("Add a log entry")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(201, "Request successful", typeof(LogEntry))]
    public async Task<IActionResult> CreateLogEntry([FromBody] CreateLogEntryFromBody request)
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





