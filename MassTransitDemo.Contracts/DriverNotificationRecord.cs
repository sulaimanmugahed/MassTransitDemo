namespace MassTransitDemo.Contracts;

public record DriverNotificationRecord
{
    public Guid DriverId { get; init; }
    public string DriverName { get; init; }
}
