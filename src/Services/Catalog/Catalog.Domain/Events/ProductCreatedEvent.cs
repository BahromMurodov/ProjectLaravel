using Catalog.Domain.Common;

namespace Catalog.Domain.Events;

/// <summary>
/// Доменное событие: Продукт создан
/// Это событие может быть обработано другими частями системы
/// </summary>
public record ProductCreatedEvent(Guid ProductId, string ProductName) : IDomainEvent
{
    public DateTime OccurredOn { get; } = DateTime.UtcNow;
}
