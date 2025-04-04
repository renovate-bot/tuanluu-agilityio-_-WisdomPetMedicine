using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api2.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService managementApplicationService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreatePetCommand command)
    {
        await managementApplicationService.Handle(command);
        return Ok();
    }
}
