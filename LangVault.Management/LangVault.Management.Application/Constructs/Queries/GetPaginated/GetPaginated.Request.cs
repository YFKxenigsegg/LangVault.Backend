namespace LangVault.Management.Application.Constructs.Queries;
public record GetPaginatedRequest(int PageNumber = PaginationDefaults.PageNumber, int PageSize = PaginationDefaults.PageSize)
    : IRequest<PaginatedList<ConstructInfo>>;
