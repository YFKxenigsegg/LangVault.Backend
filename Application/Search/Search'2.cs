using Application.Common.Extensions;

namespace Application.Search;
public class SearchHandler<TEntity, TResponse>(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<SearchRequest<TEntity, TResponse>, PaginatedList<TResponse>>
    where TEntity : LinguisticElement
    where TResponse : class
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
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
