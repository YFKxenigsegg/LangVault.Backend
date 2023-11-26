namespace Infrastructure.Interfaces;
public interface IInitialiser
{
    Task InitialiseAsync();
    Task SeedAsync();
}
