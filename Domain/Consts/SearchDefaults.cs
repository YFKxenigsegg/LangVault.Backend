namespace Domain.Consts;
public static class SearchDefaults
{
    public const int PageNumber = PaginationDefaults.PageNumber;
    public const int PageSize = PaginationDefaults.PageSize;
    public const bool Ascending = false;
    public const string OrderBy = nameof(BaseAuditableEntity.CreatedUtc);
}
