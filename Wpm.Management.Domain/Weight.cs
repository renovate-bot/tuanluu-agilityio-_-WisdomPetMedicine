namespace Wpm.Management.Domain;
public record Weight
{
    public decimal Value { get; init; }

    public Weight(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Weight must be greater than zero.");
        }

        Value = value;
    }
}
