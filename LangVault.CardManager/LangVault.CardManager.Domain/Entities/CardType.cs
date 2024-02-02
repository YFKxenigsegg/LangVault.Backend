namespace LangVault.CardManager.Domain.Entities;
public class CardType : BaseEntity
{
    public string Name { get; set; } = default!;
    public Enums.CardType Type { get; set; }
}
