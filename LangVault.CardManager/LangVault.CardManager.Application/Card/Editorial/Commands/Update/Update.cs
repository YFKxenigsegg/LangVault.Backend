namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public class UpdateHandler(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<UpdateRequest, EditorialCardInfo>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<EditorialCardInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.EditorialCards
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(EditorialCard), request.Id);
        _mapper.Map(request, entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<EditorialCardInfo>(entity);
    }
}
