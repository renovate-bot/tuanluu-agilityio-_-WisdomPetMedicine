namespace Wpm.SharedKernel;
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

    public static implicit operator Weight(decimal value)
    {
        return new Weight(value).Value;
    }
}