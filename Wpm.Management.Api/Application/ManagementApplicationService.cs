﻿using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Api2.Application;

public class ManagementApplicationService(IBreedService breedService,
                                          ManagementDbContext dbContext)
{
    public async Task Handle(CreatePetCommand command)
    {
        var breedId = new BreedId(command.BreedId, breedService);
        var newPet = new Pet(command.Id,
                             command.Name,
                             command.Age,
                             command.Color,
                             command.SexOfPet,
                             breedId);

        await dbContext.Pets.AddAsync(newPet);
        await dbContext.SaveChangesAsync();
    }
}
