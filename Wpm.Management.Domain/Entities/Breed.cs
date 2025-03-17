namespace Wpm.Management.Domain.Entities;

public class Breed : Entity
{
    public string Name { get; init; }
    public WeightRange MaleIdealWeight { get; init; }
    public WeightRange FemaleIdealWeight { get; init; }

    public Breed(Guid guid,
                 string name,
                 WeightRange maleIdealWeight,
                 WeightRange femaleIdealWeight)
    {
        Id = guid;
        Name = name;
        MaleIdealWeight = maleIdealWeight;
        FemaleIdealWeight = femaleIdealWeight;
    }
}