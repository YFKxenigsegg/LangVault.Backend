using LangVault.CardManager.Infrastructure.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangVault.CardManager.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuditableInterceptor>();
        services.AddDbContextFactory<CardManagerDbContext>((sp, options) =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly(typeof(Migrations.DependencyInjection).Assembly.FullName))
            .AddInterceptors(sp.GetRequiredService<AuditableInterceptor>()));
        services.AddScoped(options =>
            options.GetRequiredService<IDbContextFactory<CardManagerDbContext>>()
            .CreateDbContext());
        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var scopedService = scope.ServiceProvider;
        var dbContext = scopedService.GetRequiredService<IDbContextFactory<CardManagerDbContext>>();
        using var db = dbContext.CreateDbContext();
        db.Database.Migrate();
        return services;
    }
}
