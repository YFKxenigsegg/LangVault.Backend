namespace Application.Constructs.Commands;
public class CreateHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<CreateRequest, ConstructInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<ConstructInfo> Handle(CreateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = _mapper.Map<Construct>(request);
        await dbContext.Set<Construct>().AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ConstructInfo>(entity);
    }
}
