namespace LangVault.CardManager.Application.Card.Editorial.Queries;
public class GetHandler(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetRequest, EditorialCardInfo>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<EditorialCardInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<EditorialCard>()
            .ProjectTo<EditorialCardInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return result;
    }
}
