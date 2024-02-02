namespace LangVault.CardManager.Domain.Entities;
public class EditorialType : BaseEntity
{
    public string Name { get; set; } = default!;
    public Enums.EditorialType Type { get; set; }
}
