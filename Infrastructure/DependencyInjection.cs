using Infrastructure.Interceptors;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<AuditableInterceptor>();
        services.AddDbContextFactory<ApplicationDbContext>((sp, options) =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"))
            .AddInterceptors(sp.GetRequiredService<AuditableInterceptor>()));
        services.AddScoped(options =>
            options.GetRequiredService<IDbContextFactory<ApplicationDbContext>>()
            .CreateDbContext());
        services.AddScoped<IInitialiser, ApplicationDbContextInitialiser>();
        var sp = services.BuildServiceProvider();
        using var scope = sp.CreateScope();
        var scopedService = scope.ServiceProvider;
        var dbContext = scopedService.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
        using var db = dbContext.CreateDbContext();
        db.Database.EnsureCreated();
        return services;
    }
}
