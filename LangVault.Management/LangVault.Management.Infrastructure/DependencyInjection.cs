using LangVault.Management.Infrastructure.Interceptors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LangVault.Management.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuditableInterceptor>();
        services.AddDbContextFactory<ApplicationDbContext>((sp, options) =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
            x => x.MigrationsAssembly("Infrastructure.Migrations"))
            .AddInterceptors(sp.GetRequiredService<AuditableInterceptor>()));
        services.AddScoped(options =>
            options.GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
            .CreateDbContext());
        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var scopedService = scope.ServiceProvider;
        var dbContext = scopedService.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
        using var db = dbContext.CreateDbContext();
        db.Database.Migrate();
        return services;
    }
}
