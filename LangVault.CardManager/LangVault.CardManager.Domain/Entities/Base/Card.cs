namespace LangVault.CardManager.Domain.Entities.Base;
public abstract class Card : BaseAuditableEntity
{
    public string Value { get; set; } = default!;
    public Enums.CardType Type { get; set; }
}
