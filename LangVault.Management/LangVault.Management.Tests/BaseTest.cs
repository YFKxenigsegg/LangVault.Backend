namespace LangVault.Management.Tests;
public class BaseTest
{
    [SetUp]
    public async Task Setup()
    {
        await ResetDatabaseAsync();
    }
}
