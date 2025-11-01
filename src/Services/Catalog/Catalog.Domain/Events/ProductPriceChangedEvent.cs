using Catalog.Domain.Common;

namespace Catalog.Domain.Events;

/// <summary>
/// Доменное событие: Цена продукта изменилась
/// Может использоваться для логирования, уведомлений и т.д.
/// </summary>
public record ProductPriceChangedEvent(
    Guid ProductId,
    decimal OldPrice,
    decimal NewPrice) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
