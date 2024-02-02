using LangVault.EventBus;
using LangVault.EventBus.Events.Management;

namespace LangVault.Management.Application.Words.Commands;
public class CreateHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper, IEventBus eventBus)
    : IRequestHandler<CreateRequest, WordInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;
    private readonly IEventBus _eventBus = eventBus;

    public async Task<WordInfo> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = _mapper.Map<Word>(request);
        await dbContext.Set<Word>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        await _eventBus.PublishAsync(new CardCreated
        {
            Value = entity.Value
        }, cancellationToken);
        return _mapper.Map<WordInfo>(entity);
    }
}
