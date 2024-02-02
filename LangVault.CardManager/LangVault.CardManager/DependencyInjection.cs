using LangVault.CardManager.Infrastructure.Interfaces;
using LangVault.CardManager.Web;

namespace LangVault.CardManager;
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
