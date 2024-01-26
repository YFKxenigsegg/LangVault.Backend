namespace LangVault.Management.Application.Constructs.Queries;
public class GetPaginatedHanler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetPaginatedRequest, PaginatedList<ConstructInfo>>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<ConstructInfo>> Handle(GetPaginatedRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Constructs
            .OrderByDescending(x => x.CreatedUtc)
            .ProjectTo<ConstructInfo>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
