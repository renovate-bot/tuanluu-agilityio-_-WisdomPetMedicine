namespace Wpm.Management.Domain.ValueObjects;

public record BreedId
{
    private readonly IBreedService breedService;
    public Guid Value { get; init; }

    public BreedId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("BreedId cannot be empty.", nameof(value));
        }
        Value = value;
    }

    public static BreedId Create(Guid value)
    {
        return new BreedId(value);
    }

    public BreedId(Guid value, IBreedService breedService)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("BreedId cannot be empty.", nameof(value));
        }

        this.breedService = breedService;

        ValidateBreed(value);

        Value = value;
    }

    private void ValidateBreed(Guid value)
    {
        if (breedService.GetBreed(value) == null)
        {
            throw new ArgumentException("Breed not found.", nameof(value));
        } 
    }

    
}
