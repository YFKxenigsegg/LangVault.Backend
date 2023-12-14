namespace Infrastructure.Migrations;
public static class DependencyInjection
{
    public static IServiceCollection AddMigrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(config => config.AddPostgres()
                .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection"))
                .ScanIn(Assembly.GetExecutingAssembly())
                    .For.Migrations()
                    .For.EmbeddedResources());
        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var scopedService = scope.ServiceProvider;
        var runner = scopedService.GetRequiredService<IMigrationRunner>();
        runner.MigrateUp();
        return services;
    }
}
