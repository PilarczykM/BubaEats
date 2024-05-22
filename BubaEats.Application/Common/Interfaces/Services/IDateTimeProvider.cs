namespace BubaEats.Application;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
