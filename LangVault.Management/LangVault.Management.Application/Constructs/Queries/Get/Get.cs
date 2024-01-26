namespace LangVault.Management.Application.Constructs.Queries;
public class GetHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetRequest, ConstructInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<ConstructInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var result = await dbContext.Set<Construct>()
            .ProjectTo<ConstructInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
        return result;
    }
}
