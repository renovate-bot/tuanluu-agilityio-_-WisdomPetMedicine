﻿
namespace Wpm.Clinic.Domain.ValueObjects;
public record PatientId
{
    public Guid Value { get; init; }
    public PatientId(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Value cannot be empty.", nameof(value));
        }
        Value = value;
    }

    public static implicit operator PatientId(Guid value) => new PatientId(value);
}
