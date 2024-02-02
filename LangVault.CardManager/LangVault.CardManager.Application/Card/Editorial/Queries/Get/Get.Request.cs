namespace LangVault.CardManager.Application.Card.Editorial.Queries;
public record GetRequest(int Id) : IRequest<EditorialCardInfo>;
