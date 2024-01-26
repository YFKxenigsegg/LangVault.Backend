namespace LangVault.Management.Domain.Entities.Base;
public class Translation : BaseAuditableEntity
{
    public string Value { get; set; } = default!;
}
