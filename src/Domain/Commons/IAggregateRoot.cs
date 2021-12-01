namespace Domain.Commons;

public interface IAggregateRoot
{
    public List<DomainEvent> DomainEvents { get; set; }
}
