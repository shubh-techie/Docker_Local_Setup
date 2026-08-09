using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FirstApp.Jobs;

public sealed class ScheduledJobWorker : BackgroundService
{
    private readonly ILogger<ScheduledJobWorker> _logger;
    private readonly ScheduledJobOptions _options;

    public ScheduledJobWorker(
        ILogger<ScheduledJobWorker> logger,
        IOptions<ScheduledJobOptions> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var interval = TimeSpan.FromSeconds(Math.Max(1, _options.IntervalSeconds));

        _logger.LogInformation("Scheduled jobs host starting. Interval: {Interval}", interval);

        using var timer = new PeriodicTimer(interval);

        while (await timer.WaitForNextTickAsync(stoppingToken))
        {
            _logger.LogInformation("Scheduled job tick at {UtcNow}", DateTimeOffset.UtcNow);
        }
    }
}
