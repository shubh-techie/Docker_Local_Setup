namespace FirstApp.Consumers;

public sealed class RabbitMqOptions
{
    public const string SectionName = "RabbitMq";

    public string HostName { get; set; } = "localhost";
    public int Port { get; set; } = 5672;
    public string VirtualHost { get; set; } = "/";
    public string UserName { get; set; } = "guest";
    public string Password { get; set; } = "guest";
    public string ExchangeName { get; set; } = "firstapp.events";
    public string QueueName { get; set; } = "firstapp.consumer";
    public string RoutingKey { get; set; } = "#";
}
