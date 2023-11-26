namespace Application.Words.Queries;
public class GetHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetRequest, WordInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<WordInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return await dbContext.Set<Word>()
            .AsNoTracking()
            .Where(x => x.Id == request.Id)
            .ProjectTo<WordInfo>(_mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(Word), request.Id);
    }
}
