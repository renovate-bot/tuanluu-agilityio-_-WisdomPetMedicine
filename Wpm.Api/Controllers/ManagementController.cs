using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagementApplicationService managementApplicationService,
                                  ICommandHandler<SetWeightCommand> commandHandler) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Post(CreatePetCommand command)
    {
        await managementApplicationService.Handle(command);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put(SetWeightCommand command)
    {
        await commandHandler.Handle(command);
        return Ok();
    }
}
