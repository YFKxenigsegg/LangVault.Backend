using LangVault.CardManager.Domain.Entities;
using System.Reflection;

namespace LangVault.CardManager.Infrastructure;
public class CardManagerDbContext(DbContextOptions<CardManagerDbContext> options) : DbContext(options)
{
    public DbSet<CardType> CardTypes { get; set; }
    public DbSet<EditorialType> EdtitorialTypes { get; set; }
    public DbSet<EditorialCard> EditorialCards { get; set; }
    public DbSet<Translation> Tranlations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
