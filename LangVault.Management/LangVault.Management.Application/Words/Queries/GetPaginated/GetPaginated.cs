namespace LangVault.Management.Application.Words.Queries;
public class GetPaginatedHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper) 
    : IRequestHandler<GetPaginatedRequest, PaginatedList<WordInfo>>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<WordInfo>> Handle(GetPaginatedRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Words
            .OrderByDescending(x => x.CreatedUtc)
            .ProjectTo<WordInfo>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
