namespace LangVault.CardManager.Domain.Consts;
public static class SearchDefaults
{
    public const int PageNumber = PaginationDefaults.PageNumber;
    public const int PageSize = PaginationDefaults.PageSize;
    public const bool Order = Orders.Descending;
    public const string OrderBy = nameof(BaseAuditableEntity.CreatedUtc);
}
