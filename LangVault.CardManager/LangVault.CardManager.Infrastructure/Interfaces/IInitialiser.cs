namespace LangVault.CardManager.Infrastructure.Interfaces;
public interface IInitialiser
{
    Task InitialiseAsync();
    Task SeedAsync();
}
