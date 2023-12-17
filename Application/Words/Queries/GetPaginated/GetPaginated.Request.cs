namespace Application.Words.Queries;
public record GetPaginatedRequest(int PageNumber = PaginationDefaults.PageNumber, int PageSize = PaginationDefaults.PageSize)
    : IRequest<PaginatedList<WordInfo>>;
