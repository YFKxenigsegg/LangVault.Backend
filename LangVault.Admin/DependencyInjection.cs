using Infrastructure.Interfaces;
using LangVault.Admin.Web;

namespace LangVault.Admin;
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
