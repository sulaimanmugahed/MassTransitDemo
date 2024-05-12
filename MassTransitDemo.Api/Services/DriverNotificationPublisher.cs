
using MassTransit;
using MassTransitDemo.Contracts;

namespace MassTransitDemo.Api.Services;

public class DriverNotificationPublisher : IDriverNotificationPublisher
{
    private readonly ILogger<DriverNotificationPublisher> _logger;
    private readonly IPublishEndpoint _bus;

    public DriverNotificationPublisher(ILogger<DriverNotificationPublisher> logger, IPublishEndpoint bus)
    {
        _logger = logger;
        _bus = bus;
    }


    public async Task SentNotification(Guid driverId, string driverName)
    {
        _logger.LogInformation($"Driver Notification: {driverId} .. {driverName}");
        await _bus.Publish(new DriverNotificationRecord { DriverId = driverId, DriverName = driverName });
    }
}
