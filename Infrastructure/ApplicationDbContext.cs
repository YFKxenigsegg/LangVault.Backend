using System.Reflection;

namespace Infrastructure;
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Word> Words { get; set; }
    public DbSet<Construct> Constructs { get; set; }
    public DbSet<Translation> Translations { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public DbSet<WordType> WordTypes { get; set; }
    public DbSet<ConstructType> ConstructTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
