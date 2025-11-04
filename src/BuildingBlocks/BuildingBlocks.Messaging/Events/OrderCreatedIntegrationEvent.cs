namespace BuildingBlocks.Messaging.Events;

/// <summary>
/// Integration Event: Заказ создан
/// Публикуется Order Service, может потребляться другими сервисами
/// (например, Notification Service, Inventory Service)
/// </summary>
public record OrderCreatedIntegrationEvent
{
    public Guid OrderId { get; init; }
    public Guid CustomerId { get; init; }
    public decimal TotalAmount { get; init; }
    public List<OrderItemDto> Items { get; init; } = new();
    public DateTime CreatedAt { get; init; }
}

public record OrderItemDto
{
    public Guid ProductId { get; init; }
    public string ProductName { get; init; } = string.Empty;
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}
