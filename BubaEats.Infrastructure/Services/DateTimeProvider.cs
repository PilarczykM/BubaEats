using BubaEats.Application.Common.Interfaces.Services;

namespace BubaEats.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}