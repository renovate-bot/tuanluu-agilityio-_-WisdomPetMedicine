using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreatePetCommand command)
    {
        return Ok();
    }
}
