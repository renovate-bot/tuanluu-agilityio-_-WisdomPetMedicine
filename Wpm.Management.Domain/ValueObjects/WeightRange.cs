namespace Wpm.Management.Domain.Entities;

public record WeightRange
{
    public decimal From { get; init; }
    public decimal To { get; init; }
    public WeightRange(decimal from, decimal to)
    {
        From = from;
        To = to;
    }
}