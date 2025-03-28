﻿using Wpm.Management.Api.Infrastructure;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Events;

namespace Wpm.Management.Api.Application;

public class SetWeightCommandHandler : ICommandHandler<SetWeightCommand>
{
    private readonly ManagementDbContext dbContext;
    private readonly IBreedService breedService;

    public SetWeightCommandHandler(ManagementDbContext dbContext,
                                   IBreedService breedService)
    {
        this.dbContext = dbContext;
        this.breedService = breedService;

        DomainEvents.PetWeightUpdated.Subscribe(e =>
        {
            // Set a message in the event log
        });
    }

    public async Task Handle(SetWeightCommand command)
    {
        var pet = await dbContext.Pets.FindAsync(command.Id);
        if (pet == null)
        {
            throw new ArgumentException("Pet not found.", nameof(command.Id));
        }
        pet.SetWeight(command.Weight, breedService);
        await dbContext.SaveChangesAsync();
    }
}
