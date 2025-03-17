namespace Wpm.Management.Domain;

public enum SexOfPet
{
    Male,
    Female
}

public class Pet : Entity
{
    public string Name { get; init; }
    public int Age { get; init; }
    public string Color { get; init; }
    public Weight Weight { get; init; }
    public SexOfPet Sex { get; init; }

    public Pet(Guid guid,
               string name,
               int age,
               string color,
               Weight weight,
               SexOfPet sex)
    {
        Id = guid;
        Name = name;
        Age = age;
        Color = color;
        Weight = weight;
        Sex = sex;
    }
}
