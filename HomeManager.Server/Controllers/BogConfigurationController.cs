using HomeManager.Server.Models;
using HomeManager.Server.Repositories;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HomeManager.Server.Controllers;

// TODO: Need to think through "private" endpoints vs "public" endpoints
// Many of these log endpoints shouldn't be "public" or exposed on Swagger

[ApiController]
[Route("api/[controller]")]
public class BotConfigurationController : ControllerBase
{
    
}