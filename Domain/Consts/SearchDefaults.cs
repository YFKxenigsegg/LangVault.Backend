namespace Domain.Consts;
public static class SearchDefaults
{
    public const int PageNumber = 1;
    public const int PageSize = 10;
    public const bool Ascending = false;
    public const string OrderBy = nameof(BaseAuditableEntity.CreatedUtc);
}
