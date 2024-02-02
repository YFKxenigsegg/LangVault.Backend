namespace LangVault.CardManager.Domain.Entities;
public class EditorialCard : Card
{
    public ICollection<Translation> Translations { get; set; } = default!;
}
