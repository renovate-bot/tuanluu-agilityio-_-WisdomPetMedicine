using Wpm.Clinic.Domain.Events;
using Wpm.Clinic.Domain.ValueObjects;
using Wpm.SharedKernel;

namespace Wpm.Clinic.Domain.Entities;

public class Consultation : AggregateRoot
{
    private readonly List<DrugAdministration> administeredDrugs = new();
    private readonly List<VitalSigns> vitalSignReadings = new();
    public DateTimeRange When { get; private set; }
    public Text? Diagnosis { get; private set; }
    public Text? Treatment { get; private set; }
    public PatientId PatientId { get; private set; }
    public Weight? CurrentWeight { get; private set; }
    public ConsultationStatus Status { get; private set; }
    public IReadOnlyCollection<DrugAdministration> AdministeredDrugs => administeredDrugs;
    public IReadOnlyCollection<VitalSigns> VitalSignReadings => vitalSignReadings;

    public Consultation(PatientId patientId)
    {
        ApplyDomainEvent(new ConsultationStarted(Guid.NewGuid(),
                                                 patientId,
                                                 DateTime.UtcNow));
    }

    public Consultation(IEnumerable<IDomainEvent> domainEvents) => Load(domainEvents);

    public void RegisterVitalSigns(IEnumerable<VitalSigns> vitalSigns)
    {
        ValidateConsultationStatus();
        vitalSignReadings.AddRange(vitalSigns);
    }

    public void AdministerDrug(DrugId drugId, Dose dose)
    {
        ValidateConsultationStatus();
        var newDrugAdministration = new DrugAdministration(drugId, dose);
        administeredDrugs.Add(newDrugAdministration);
    }

    public void End()
    {
        ApplyDomainEvent(new ConsultationEnd(Id, DateTime.UtcNow));
    }

    public void SetWeight(Weight weight)
    {
        ApplyDomainEvent(new WeightUpdated(Id, weight));
    }

    public void SetDiagnosis(Text diagnosis)
    {
        ApplyDomainEvent(new DiagnosisUpdated(Id, diagnosis));
    }

    public void SetTreatment(Text treatment)
    {
        ApplyDomainEvent(new TreatmentUpdated(Id, treatment));
    }

    private void ValidateConsultationStatus()
    {
        if (Status == ConsultationStatus.Closed)
        {
            throw new InvalidOperationException("The consultation is already closed.");
        }
    }

    protected override void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent)
    {
        switch (domainEvent) 
        {
            case ConsultationStarted consultationStarted:
                Id = consultationStarted.Id;
                PatientId = consultationStarted.PatientId;
                Status = ConsultationStatus.Open;
                When = consultationStarted.StartedAt;
                break;
            case DiagnosisUpdated diagnosisUpdated:
                ValidateConsultationStatus();
                Diagnosis = diagnosisUpdated.Diagnosis;
                break;
            case TreatmentUpdated treatmentUpdated:
                ValidateConsultationStatus();
                Treatment = treatmentUpdated.Treatment;
                break;
            case WeightUpdated weightUpdated:
                ValidateConsultationStatus();
                CurrentWeight = weightUpdated.Weight;
                break;
            case ConsultationEnd consultationEnd:
                ValidateConsultationStatus();
                if (Diagnosis == null || Treatment == null || CurrentWeight == null)
                {
                    throw new InvalidOperationException("The consultation cannot be ended.");
                }
                Status = ConsultationStatus.Closed;
                When = new DateTimeRange(When.StartedAt, DateTime.UtcNow);
                break;
        }
    }
}

public enum ConsultationStatus
{
    Open,
    Closed
}