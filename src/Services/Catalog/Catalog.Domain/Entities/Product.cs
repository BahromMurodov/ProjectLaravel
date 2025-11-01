using Catalog.Domain.Common;
using Catalog.Domain.Events;

namespace Catalog.Domain.Entities;

/// <summary>
/// Сущность Product - товар в каталоге
/// Содержит всю бизнес-логику, связанную с товаром
/// </summary>
public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public int Stock { get; private set; }
    public string ImageUrl { get; private set; } = string.Empty;

    // Навигационное свойство
    public Guid CategoryId { get; private set; }
    public Category? Category { get; private set; }

    // Приватный конструктор для EF Core
    private Product() { }

    // Фабричный метод для создания нового продукта
    public static Product Create(
        string name,
        string description,
        decimal price,
        int stock,
        string imageUrl,
        Guid categoryId)
    {
        // Валидация бизнес-правил
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));

        if (price <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(price));

        if (stock < 0)
            throw new ArgumentException("Stock cannot be negative", nameof(stock));

        var product = new Product
        {
            Id = Guid.NewGuid(),
            Name = name,
            Description = description,
            Price = price,
            Stock = stock,
            ImageUrl = imageUrl,
            CategoryId = categoryId,
            CreatedAt = DateTime.UtcNow
        };

        // Добавляем доменное событие "Продукт создан"
        product.AddDomainEvent(new ProductCreatedEvent(product.Id, product.Name));

        return product;
    }

    // Методы для изменения состояния с бизнес-логикой
    public void UpdatePrice(decimal newPrice)
    {
        if (newPrice <= 0)
            throw new ArgumentException("Price must be greater than zero", nameof(newPrice));

        var oldPrice = Price;
        Price = newPrice;
        UpdatedAt = DateTime.UtcNow;

        if (oldPrice != newPrice)
        {
            AddDomainEvent(new ProductPriceChangedEvent(Id, oldPrice, newPrice));
        }
    }

    public void UpdateStock(int quantity)
    {
        if (Stock + quantity < 0)
            throw new InvalidOperationException("Insufficient stock");

        Stock += quantity;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Update(string name, string description, string imageUrl, Guid categoryId)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Product name cannot be empty", nameof(name));

        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        CategoryId = categoryId;
        UpdatedAt = DateTime.UtcNow;
    }
}
