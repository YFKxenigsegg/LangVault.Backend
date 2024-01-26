using LangVault.Management.Infrastructure.Interfaces;

namespace LangVault.Management.Infrastructure;
public class ApplicationDbContextInitialiser(IDbContextFactory<ApplicationDbContext> dbContextFactory)
    : IInitialiser
{
    private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory = dbContextFactory;

    public async Task InitialiseAsync()
    {
        try
        {
            using var dbContext = await _dbContextFactory.CreateDbContextAsync();
            if (dbContext.Database.IsNpgsql())
            {
                await dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // add default roles
        // add default users
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        if (!dbContext.Tags.Any()) await dbContext.Tags.AddRangeAsync(InitialData.Tags);
        if (!dbContext.WordTypes.Any()) await dbContext.WordTypes.AddRangeAsync(InitialData.WordTypes);
        if (!dbContext.ConstructTypes.Any()) await dbContext.ConstructTypes.AddRangeAsync(InitialData.ConstructTypes);
        await dbContext.SaveChangesAsync();
    }
}
