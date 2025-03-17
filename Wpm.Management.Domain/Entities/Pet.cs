using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Entities;

public enum SexOfPet
{
    Male,
    Female
}

public enum WeightClass
{
    Unknown,
    Ideal,
    Underweight,
    Overweight
}

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; init; }
    public Weight Weight { get; private set; }
    public WeightClass WeightClass { get; private set; }
    public SexOfPet Sex { get; init; }

    public BreedId BreedId { get; init; }

    public Pet(Guid guid,
               string name,
               int age,
               string color,
               SexOfPet sex,
               BreedId breedId)
    {
        Id = guid;
        Name = name;
        Age = age;
        Color = color;
        Sex = sex;
        BreedId = breedId;
    }

    public void SetWeight(Weight weight)
    {
        Weight = weight;
    }

    private void SetWeightClass(IBreedService breedService)
    {
        var desertBreed = breedService.GetBreed(BreedId.Value);

        var (from, to) = SexOfPet switch
        {
            SexOfPet.Male => (desertBreed.MaleIdealWeight.From, desertBreed.MaleIdealWeight.To),
            SexOfPet.Female => (desertBreed.FemaleIdealWeight.From, desertBreed.FemaleIdealWeight.To),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
