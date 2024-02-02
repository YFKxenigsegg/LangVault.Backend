namespace LangVault.CardManager.Tests;
public class BaseTest
{
    [SetUp]
    public async Task Setup()
    {
        await ResetDatabaseAsync();
    }
}
