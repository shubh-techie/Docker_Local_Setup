using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Consumers;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRabbitMqConsumers(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<RabbitMqOptions>(configuration.GetSection(RabbitMqOptions.SectionName));
        services.AddHostedService<RabbitMqConsumerWorker>();

        return services;
    }
}
