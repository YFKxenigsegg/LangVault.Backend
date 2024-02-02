using LangVault.CardManager.Application.Search;

namespace LangVault.CardManager.Application.Common.Extensions;
public static class FilterExtensions
{
    public static IQueryable<TEntity> ApplyFilter<TEntity, TResponse>(this IQueryable<TEntity> query, SearchRequest<TEntity, TResponse> request)
        where TEntity : Domain.Entities.Base.Card
    {
        if (!string.IsNullOrEmpty(request.Value)) query = query.Where(x => x.Value.Contains(request.Value));
        if (request.Type.HasValue) query = query.Where(x => (int)x.Type == request.Type);
        return query;
    }
}
