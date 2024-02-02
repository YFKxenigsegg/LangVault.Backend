using LangVault.CardManager.Infrastructure.Interfaces;

namespace LangVault.CardManager.Infrastructure;
public class CardManagerDbContextInitialiser(IDbContextFactory<CardManagerDbContext> dbContextFactory)
    : IInitialiser
{
    private readonly IDbContextFactory<CardManagerDbContext> _dbContextFactory = dbContextFactory;

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
        var dbContext = await _dbContextFactory.CreateDbContextAsync();
        if (!dbContext.CardTypes.Any()) await dbContext.CardTypes.AddRangeAsync(InitialData.CardTypes);
        await dbContext.SaveChangesAsync();
    }
}
