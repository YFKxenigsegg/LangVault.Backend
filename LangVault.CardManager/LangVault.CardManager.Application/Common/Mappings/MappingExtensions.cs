namespace LangVault.CardManager.Application.Common.Mappings;
public static class MappingExtensions
{
    public static Task<PaginatedList<TDestination>> PaginatedListAsync<TDestination>(this IQueryable<TDestination> queryable, int pageNumber, int pageSize)
        where TDestination : class
        => PaginatedList<TDestination>.CreateAsync(queryable.AsNoTracking(), pageNumber, pageSize);

    public static IMappingExpression<TSource, TDestination> IgnoreAllMembers<TSource, TDestination>(this IMappingExpression<TSource, TDestination> expression)
    {
        var destinationType = typeof(TDestination);
        foreach (var property in destinationType.GetProperties())
            expression.ForMember(property.Name, opt => opt.Ignore());
        return expression;
    }
}
