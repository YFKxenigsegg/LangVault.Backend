namespace LangVault.CardManager.Application.Card.Editorial;
public partial class EditorialCardInfo : BaseInfo, IMapFrom<EditorialCardInfo>
{
    public string Value { get; set; } = default!;
    public Domain.Enums.EditorialType Type { get; set; }
    public ICollection<string> Translations { get; set; } = default!;
}
