namespace Application.Constructs.Commands;
public class UpdateHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<UpdateRequest, ConstructInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<ConstructInfo> Handle(UpdateRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        var entity = await dbContext.Constructs
            .Where(x => x.Id == request.Id)
            .FirstOrDefaultAsync(cancellationToken) ?? throw new NotFoundException(nameof(Construct), request.Id);
        _mapper.Map(request, entity);
        await dbContext.SaveChangesAsync(cancellationToken);
        return _mapper.Map<ConstructInfo>(entity);
    }
}
