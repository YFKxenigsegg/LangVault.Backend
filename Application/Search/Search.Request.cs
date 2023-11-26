namespace Application.Search;
public class SearchRequest<TEntity, TResponse> : IRequest<PaginatedList<TResponse>>
{
    public string? Value { get; set; }
    public string OrderBy { get; set; } = SearchDefaults.OrderBy;
    public bool Ascending { get; set; } = SearchDefaults.Ascending;
    public int PageNumber { get; set; } = SearchDefaults.PageNumber;
    public int PageSize { get; set; } = SearchDefaults.PageSize;
}
