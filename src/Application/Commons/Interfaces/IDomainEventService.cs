using Domain.Commons;

namespace Application.Commons.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
