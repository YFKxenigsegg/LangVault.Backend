namespace Domain.Entities.Base;
public abstract class LinguisticElement : BaseAuditableEntity
{
    public string Value { get; set; } = default!;
    public int Type { get; set; }
    public ICollection<Translation> Translations { get; set; } = default!;
}
