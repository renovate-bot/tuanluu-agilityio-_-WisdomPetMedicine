namespace Wpm.Management.Api.Application;

public class ManagementApplicationService
{
    public async Task Handle(CreatePetCommand command)
    {
        var newPet = new Pet(command.Id,
                             command.Name,
                             command.Age,
                             command.Color,
                             command.SexOfPet,
                             null);
    }
}
