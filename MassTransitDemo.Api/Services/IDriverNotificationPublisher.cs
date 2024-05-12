namespace MassTransitDemo.Api.Services;

public interface IDriverNotificationPublisher
{
    Task SentNotification(Guid driverId, string driverName);
}
