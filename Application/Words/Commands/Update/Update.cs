namespace Application.Words.Commands;
public class UpdateHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<UpdateRequest, WordInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<WordInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.Words
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(Word), request.Id);
        _mapper.Map(request, entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<WordInfo>(entity);
    }
}
