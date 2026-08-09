using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace FirstApp.Consumers;

public sealed class RabbitMqConsumerWorker : BackgroundService
{
    private readonly ILogger<RabbitMqConsumerWorker> _logger;
    private readonly RabbitMqOptions _options;

    public RabbitMqConsumerWorker(
        ILogger<RabbitMqConsumerWorker> logger,
        IOptions<RabbitMqOptions> options)
    {
        _logger = logger;
        _options = options.Value;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation(
            "RabbitMQ consumer starting. Host: {HostName}:{Port}, Exchange: {ExchangeName}, Queue: {QueueName}, RoutingKey: {RoutingKey}",
            _options.HostName,
            _options.Port,
            _options.ExchangeName,
            _options.QueueName,
            _options.RoutingKey);

        while (!stoppingToken.IsCancellationRequested)
        {
            // Wire RabbitMQ.Client consumption here when the broker contract is finalized.
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }
}
