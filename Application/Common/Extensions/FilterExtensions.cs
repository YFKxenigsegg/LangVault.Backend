using Application.Search;

namespace Application.Common.Extensions;
public static class FilterExtensions
{
    public static IQueryable<TEntity> ApplyFilter<TEntity, TResponse>(this IQueryable<TEntity> query, SearchRequest<TEntity, TResponse> request)
        where TEntity : LinguisticElement
    {
        if (!string.IsNullOrEmpty(request.Value)) query = query.Where(x => x.Value.Contains(request.Value));
        if (request.Type.HasValue) query = query.Where(x => x.Type == request.Type);
        return query;
    }
}
