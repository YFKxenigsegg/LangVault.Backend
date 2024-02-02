namespace LangVault.CardManager.Application.Card.Editorial.Commands;
public class CreateHandler(IDbContextFactory<CardManagerDbContext> dbContextFactory, IMapper mapper, IEventBus eventBus)
    : IRequestHandler<CreateRequest, EditorialCardInfo>
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;
    private readonly IEventBus _eventBus = eventBus;

    public async Task<EditorialCardInfo> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = _mapper.Map<EditorialCard>(request);
        await dbContext.Set<EditorialCard>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await _eventBus.PublishAsync(new CardCreated
        {
            Value = entity.Value
        }, cancellationToken);
        return _mapper.Map<EditorialCardInfo>(entity);
    }
}
