using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.API;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder AddFirstAppApi(this IServiceCollection services)
    {
        return services
            .AddControllers()
            .AddApplicationPart(typeof(ServiceCollectionExtensions).Assembly);
    }
}
