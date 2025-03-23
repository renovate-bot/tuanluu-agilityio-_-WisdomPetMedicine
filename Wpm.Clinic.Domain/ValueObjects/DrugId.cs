namespace Wpm.Clinic.Domain;

public record DrugId
{
    public Guid Value { get; set; }
    public DrugId(Guid value)
    {
        Value = value;
    }

    public static implicit operator DrugId(Guid value)
    {
        return new DrugId(value);
    }
}
