using LangVault.Management.Application.Masterdata.ConstructTypes;
using LangVault.Management.Application.Masterdata.Tags;
using LangVault.Management.Application.Masterdata.WordTypes;
using AutoMapper.QueryableExtensions;

namespace Application.Masterdata.Queries;
public class GetHandler(IDbContextFactory<ApplicationDbContext> dbContextFactory, IMapper mapper)
    : IRequestHandler<GetRequest, MasterdataInfo>
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;
    private readonly IMapper _mapper = mapper;

    public async Task<MasterdataInfo> Handle(GetRequest request, CancellationToken cancellationToken)
    {
        using var dbContext = await _dbContextFactory.CreateDbContextAsync(cancellationToken);
        return new MasterdataInfo
        {
            Tags = await dbContext.Tags.OrderBy(x => x.Priority).ProjectTo<TagInfo>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
            WordTypes = await dbContext.WordTypes.ProjectTo<WordTypeInfo>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
            ConstructTypes = await dbContext.ConstructTypes.ProjectTo<ConstructTypeInfo>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken),
        };
    }
}
