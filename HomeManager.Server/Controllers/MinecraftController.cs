using HomeManager.Server.Models;
using HomeManager.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MinecraftController : ControllerBase
{
    private readonly MinecraftService _minecraftService;
    private readonly LogService _logService;

    public MinecraftController(MinecraftService minecraftService, LogService logService)
    {
        _logService = logService;
        _minecraftService = minecraftService;
    }

    [HttpGet]
    [SwaggerOperation("Get minecraft server status")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [SwaggerResponse(200, "Request successful", typeof(User[]))]
    public async Task<IActionResult> GetAllUsers()
    {
        // TODO: hardcode for now
        var status = await _minecraftService.PingServerAsync("96.29.137.136");
        return Ok(status);
    }
}