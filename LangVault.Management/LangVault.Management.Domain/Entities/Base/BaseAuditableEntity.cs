namespace LangVault.Management.Domain.Entities.Base;
public abstract class BaseAuditableEntity : BaseEntity
{
    public string? CreatedBy { get; set; }
    public DateTime CreatedUtc { get; set; }
    public DateTime? ModifiedUtc { get; set; }
}
