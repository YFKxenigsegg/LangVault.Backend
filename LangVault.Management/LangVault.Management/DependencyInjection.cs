using LangVault.Management.Infrastructure.Interfaces;
using LangVault.Management.Web;

namespace LangVault.Management;
public static class DependencyInjection
{
    public static IServiceCollection AddAdmin(this IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserProvider, CurrentUserProvider>();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
        services.AddHttpContextAccessor();
        return services;
    }
}
