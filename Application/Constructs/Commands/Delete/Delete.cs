namespace Application.Constructs.Commands;
public class DeleteHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<DeleteRequest, Unit>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.Constructs
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(Construct), request.Id);
        dbContext.Set<Construct>().Remove(entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
