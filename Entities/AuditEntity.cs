namespace Arcaim.Mail.Entities;

public abstract class AuditEntity<T> : BaseEntity<T>
{
  public required string CreatedBy { get; set; }
  public required DateTime CreatedOn { get; set; }
}