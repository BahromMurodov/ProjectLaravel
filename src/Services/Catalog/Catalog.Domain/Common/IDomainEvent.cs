namespace Catalog.Domain.Common;

/// <summary>
/// Интерфейс для доменных событий
/// Доменные события - это то, что произошло в домене и может быть интересно другим частям системы
/// </summary>
public interface IDomainEvent
{
    DateTime OccurredOn { get; }
}
