using MassTransit;
using MassTransitDemo.Contracts;

namespace MassTransitDemo.SecondApi.Services;

public class DriverNotificationConsumer : IConsumer<DriverNotificationRecord>
{
    private readonly ILogger<DriverNotificationConsumer> _logger;

    public DriverNotificationConsumer(ILogger<DriverNotificationConsumer> logger)
    {
        _logger = logger;
    }

    public Task Consume(ConsumeContext<DriverNotificationRecord> context)
    {
        _logger.LogInformation($"Second Api logs: Id: {context.Message.DriverId} .. Name: {context.Message.DriverName}");
        return Task.CompletedTask;
    }
}
