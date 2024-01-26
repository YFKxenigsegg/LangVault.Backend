namespace LangVault.Management.Application.Search;
public class SearchRequest<TEntity, TResponse> : IRequest<PaginatedList<TResponse>>
{
    public string? Value { get; set; }
    public int? Type { get; set; }
    public string OrderBy { get; set; } = SearchDefaults.OrderBy;
    public bool Order { get; set; } = SearchDefaults.Order;
    public int PageNumber { get; set; } = SearchDefaults.PageNumber;
    public int PageSize { get; set; } = SearchDefaults.PageSize;
}
