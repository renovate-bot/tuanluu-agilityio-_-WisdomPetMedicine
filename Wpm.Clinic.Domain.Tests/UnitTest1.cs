using Wpm.Clinic.Domain.ValueObjects;

namespace Wpm.Clinic.Domain.Tests;

public class UnitTest1
{
    [Fact]
    public void Consultation_should_be_open()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Equal(ConsultationStatus.Open, c.Status);
    }

    [Fact]
    public void Consultation_should_not_have_ended_timestamp()
    {
        var c = new Consultation(Guid.NewGuid());
        Assert.Null(c.EndedAt);
    }

    [Fact]
    public void Consultation_should_end_with_complete_data()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(5);
        c.End();
        Assert.Equal(ConsultationStatus.Closed, c.Status);
    }

    [Fact]
    public void Consultation_should_not_allow_weight_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(5);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetWeight(6));
    }

    [Fact]
    public void Consultation_should_not_allow_treatment_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(5);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetTreatment("New treatment"));
    }

    [Fact]
    public void Consultation_should_not_allow_diagnosis_updates_when_closed()
    {
        var c = new Consultation(Guid.NewGuid());
        c.SetTreatment("Treatment");
        c.SetDiagnosis("Diagnosis");
        c.SetWeight(5);
        c.End();
        Assert.Throws<InvalidOperationException>(() => c.SetDiagnosis("New diagnosis"));
    }

    [Fact]
    public void Consultation_should_administer_drug()
    {
        var drugId = new DrugId(Guid.NewGuid());
        var c = new Consultation(Guid.NewGuid());
        c.AdministerDrug(drugId, new Dose(5, Dose.UnitOfMeasure.tablet));
        Assert.True(c.AdministeredDrugs.Count == 1);
        Assert.True(c.AdministeredDrugs.First().DrugId == drugId);
    }

    [Fact]
    public void Consultation_should_register_vital_signs()
    {
        var vitalSigns = new List<VitalSigns>
        {
            new VitalSigns(37.5m, 120, 80),
            new VitalSigns(37.5m, 120, 80)
        };
        var c = new Consultation(Guid.NewGuid());
        c.RegisterVitalSigns(vitalSigns);
        Assert.True(c.VitalSignsReadings.Count == 2);
    }
}
