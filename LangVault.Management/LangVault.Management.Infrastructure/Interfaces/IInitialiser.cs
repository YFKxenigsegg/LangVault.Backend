namespace LangVault.Management.Infrastructure.Interfaces;
public interface IInitialiser
{
    Task InitialiseAsync();
    Task SeedAsync();
}
