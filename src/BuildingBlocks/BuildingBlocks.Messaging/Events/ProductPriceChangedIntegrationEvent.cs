namespace BuildingBlocks.Messaging.Events;

/// <summary>
/// Integration Event: Цена продукта изменилась
/// Это событие публикуется Catalog Service и потребляется Order Service
/// Integration Events используются для коммуникации между микросервисами
/// </summary>
public record ProductPriceChangedIntegrationEvent
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public decimal OldPrice { get; init; }
    public decimal NewPrice { get; init; }
    public DateTime OccurredAt { get; init; }
}
