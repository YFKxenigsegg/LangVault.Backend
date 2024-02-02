namespace LangVault.CardManager.Application.Card.Editorial.Queries;
public record GetPaginatedRequest(int PageNumber = PaginationDefaults.PageNumber, int PageSize = PaginationDefaults.PageSize)
    : IRequest<PaginatedList<EditorialCardInfo>>;
