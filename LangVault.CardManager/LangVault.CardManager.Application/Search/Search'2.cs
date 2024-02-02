using LangVault.CardManager.Application.Common.Extensions;

namespace LangVault.CardManager.Application.Search;
public class SearchHandler<TEntity, TResponse>(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<SearchRequest<TEntity, TResponse>, PaginatedList<TResponse>>
    where TEntity : Domain.Entities.Base.Card
    where TResponse : class
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<TResponse>> Handle(SearchRequest<TEntity, TResponse> request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Set<TEntity>()
            .ApplyFilter(request)
            .ApplyOrder(request.OrderBy, request.Order)
            .ProjectTo<TResponse>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
