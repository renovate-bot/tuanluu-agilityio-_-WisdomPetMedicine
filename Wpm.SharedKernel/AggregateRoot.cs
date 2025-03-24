namespace Wpm.SharedKernel;

public abstract class AggregateRoot : Entity
{
    private readonly List<IDomainEvent> changes = new();

    public int Version { get; private set; }
    
    public IReadOnlyList<IDomainEvent> GetChanges() => changes.AsReadOnly();

    public void ClearChanges() => changes.Clear();

    protected void ApplyDomainEvent(IDomainEvent domainEvent)
    {
        ChangeStateByUsingDomainEvent(domainEvent);
        changes.Add(domainEvent);
        Version++;
    }

    public void Load(IEnumerable<IDomainEvent> history)
    {
        foreach (var domainEvent in history)
        {
            ApplyDomainEvent(domainEvent);
        }
        ClearChanges();
    }

    protected abstract void ChangeStateByUsingDomainEvent(IDomainEvent domainEvent);
}
