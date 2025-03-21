using Wpm.Management.Domain;
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Api.Infrastructure;

public class BreedService : IBreedService
{
    // generate new guids for the breeds

    public readonly List<Breed> breeds =
    [
        new Breed(Guid.Parse("4d42988e-8775-4319-b908-21362806fffc"), "Golden Retriever", new WeightRange(10, 20), new WeightRange(55, 65)),
        new Breed(Guid.Parse("6d0e1205-d392-4312-968f-b1ee8e158a19"), "Labrador Retriever", new WeightRange(10, 20), new WeightRange(55, 65)),
        new Breed(Guid.Parse("d1da8a48-aa9b-4461-81b5-7a2a554fe47f"), "Poodle", new WeightRange(5, 10), new WeightRange(5, 10))
    ];

    public Breed? GetBreed(Guid breedId)
    {
        if (breedId == Guid.Empty)
        {
            throw new ArgumentException("BreedId cannot be empty.", nameof(breedId));
        }
        var result = breeds.Find(b => b.Id == breedId);
        return result ?? throw new ArgumentException("Breed not found.", nameof(breedId));
    }
}
