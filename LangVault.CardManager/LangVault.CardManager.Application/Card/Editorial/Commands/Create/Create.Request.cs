namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public record CreateRequest(string Value, Domain.Enums.EditorialType Type, ICollection<string> Translations = default!)
    : IRequest<EditorialCardInfo>;
