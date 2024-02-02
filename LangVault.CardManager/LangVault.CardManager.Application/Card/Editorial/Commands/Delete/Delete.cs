namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public class DeleteHandler(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<DeleteRequest, Unit>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.EditorialCards
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(EditorialCard), request.Id);
        dbContext.Set<EditorialCard>().Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
