using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Net;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    [SwaggerOperation("Iz ping")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> Get()
    {
        return Ok("OK");
    }

    [HttpPost]
    [SwaggerOperation("Iz post ping")]
    [SwaggerResponse(200, "Request successful", typeof(Task<IActionResult>))]
    public async Task<IActionResult> Post(String input)
    {
        return Ok($"OK: {input}");
    }
}