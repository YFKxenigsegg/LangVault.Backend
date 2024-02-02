using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LangVault.Shared.Web;
public static class ConfigurationExtensions
{
    public static TModel GetOptions<TModel>(this IServiceCollection service, string section) where TModel : new()
    {
        var model = new TModel();
        var configuration = service.BuildServiceProvider().GetService<IConfiguration>();
        configuration?.GetSection(section).Bind(model);
        return model;
    }

    public static void AddValidateOptions<TModel>(this IServiceCollection service) where TModel : class, new()
    {
        service.AddOptions<TModel>()
            .BindConfiguration(typeof(TModel).Name).ValidateOnStart(); // warning!
            //.ValidateDataAnnotations();
        service.AddSingleton(x => x.GetRequiredService<IOptions<TModel>>().Value);
    }
}
