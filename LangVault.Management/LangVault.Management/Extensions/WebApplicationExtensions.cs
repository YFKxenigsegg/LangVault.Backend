namespace LangVault.Management.Extensions;
internal static class WebApplicationExtensions
{
    public static async Task RunAppAsync(this WebApplication app)
    {
        await using var scope = app.Services.CreateAsyncScope();
        var mapper = scope.ServiceProvider.GetRequiredService<IMapper>();
        app.Logger.LogInformation("----- AutoMapper: mappings are being validated...");
        mapper.ConfigurationProvider.AssertConfigurationIsValid();
        mapper.ConfigurationProvider.CompileMappings();
        app.Logger.LogInformation("----- AutoMapper: mappings are valid!");

        app.Logger.LogInformation("----- Databases are being migrated....");
        await app.MigrateDatabaseAsync(scope);
    }

    private static async Task MigrateDatabaseAsync(this WebApplication app, AsyncServiceScope scope)
    {

    }
}
