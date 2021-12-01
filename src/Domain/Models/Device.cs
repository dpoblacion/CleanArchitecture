using Domain.Commons;

namespace Domain.Models;

public class Device : AuditableEntity, IAggregateRoot
{
    public DeviceType Type { get; set; }

    public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
}
