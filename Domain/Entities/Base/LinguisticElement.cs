namespace Domain.Entities.Base;
public abstract class LinguisticElement : BaseAuditableEntity
{
    public string Value { get; set; } = default!;
    public ICollection<Translation> Translations { get; set; } = default!;
}
