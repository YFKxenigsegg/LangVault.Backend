namespace LangVault.CardManager.Application.Card.Editorial.Queries;
public class GetPaginatedHanler(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetPaginatedRequest, PaginatedList<EditorialCardInfo>>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<EditorialCardInfo>> Handle(GetPaginatedRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.EditorialCards
            .OrderByDescending(x => x.CreatedUtc)
            .ProjectTo<EditorialCardInfo>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
