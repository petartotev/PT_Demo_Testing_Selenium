using Microsoft.AspNetCore.Mvc;

namespace SeleniumDemoApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new { message = "Hello from .NET 8 Web API!" });
    }
}