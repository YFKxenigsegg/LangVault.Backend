namespace UnitTests;
public class BaseTest
{
    [SetUp]
    public async Task Setup()
    {
        await ResetDatabaseAsync();
    }
}
