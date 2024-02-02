namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public record DeleteRequest(int Id) : IRequest<Unit>;