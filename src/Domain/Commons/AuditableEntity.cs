namespace Domain.Commons;

public abstract class AuditableEntity : Entity
{
    public DateTimeOffset Created { get; set; }

    public Guid CreatedBy { get; set; }

    public DateTimeOffset LastModified { get; set; }

    public Guid LastModifiedBy { get; set; }
}
