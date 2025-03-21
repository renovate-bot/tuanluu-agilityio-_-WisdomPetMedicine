

using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain;

public interface IBreedService
{
    Breed? GetBreed(Guid breedId);
}

public class FakeBreedService : IBreedService
{
    public readonly List<Breed> breeds =
    [
        new Breed(Guid.NewGuid(), "Golden Retriever", new WeightRange(10, 20), new WeightRange(55, 65)),
        new Breed(Guid.NewGuid(), "Labrador Retriever", new WeightRange(10, 20), new WeightRange(55, 65)),
        new Breed(Guid.NewGuid(), "Poodle", new WeightRange(5, 10), new WeightRange(5, 10))
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

public interface IManagementRepository
{
    Pet? GetById(Guid id);
    IEnumerable<Pet> GetAll();
    void Insert(Pet pet);
    void Update(Pet pet);
    void Delete(Pet pet);
}