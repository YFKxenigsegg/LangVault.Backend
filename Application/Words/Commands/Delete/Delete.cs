namespace Application.Words.Commands;
public class DeleteHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<DeleteRequest, Unit>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.Words
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(Word), request.Id);
        dbContext.Set<Word>().Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
