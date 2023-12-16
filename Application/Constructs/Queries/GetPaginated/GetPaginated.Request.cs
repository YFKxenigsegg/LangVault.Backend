namespace Application.Constructs.Queries;
public record GetPaginatedRequest(int PageNumber = 1, int PageSize = 10)
    : IRequest<PaginatedList<ConstructInfo>>;
