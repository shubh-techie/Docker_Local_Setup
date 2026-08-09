using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FirstApp.Jobs;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddScheduledJobs(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<ScheduledJobOptions>(configuration.GetSection(ScheduledJobOptions.SectionName));
        services.AddHostedService<ScheduledJobWorker>();

        return services;
    }
}
