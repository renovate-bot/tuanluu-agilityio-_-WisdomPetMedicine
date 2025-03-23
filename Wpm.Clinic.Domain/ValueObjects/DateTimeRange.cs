namespace Wpm.Clinic.Domain.ValueObjects;

public record DateTimeRange
{
    public DateTime StartedAt { get; }
    public DateTime? EndedAt { get; }

    // Parameterless constructor for EF Core
    private DateTimeRange() { }

    public DateTimeRange(DateTime startedAt, DateTime endedAt)
    {
        ValidateRange(startedAt, endedAt);
        StartedAt = startedAt;
        EndedAt = endedAt;
    }

    public DateTimeRange(DateTime startAt)
    {
        StartedAt = startAt;
    }

    public string Duration
    {
        get
        {
            if (EndedAt == null)
            {
                return "Ongoing";
            }

            TimeSpan elapsedTime = EndedAt.Value - StartedAt;
            return $"Duration: {elapsedTime.Days} days, {elapsedTime.Hours} hours, {elapsedTime.Minutes} minutes, {elapsedTime.Seconds} seconds";
        }
    }

    private void ValidateRange(DateTime started, DateTime ended)
    {
        if (started >= ended)
        {
            throw new ArgumentException("Start date must be before ended date.");
        }
    }

    public static implicit operator DateTimeRange(DateTime startedAt)
    {
        return new DateTimeRange(startedAt);
    }
}
