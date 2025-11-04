using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configurations;

/// <summary>
/// Конфигурация Entity Framework для сущности Product
/// Определяет структуру таблицы в базе данных с помощью Fluent API
/// </summary>
public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        // Название таблицы
        builder.ToTable("Products");

        // Первичный ключ
        builder.HasKey(p => p.Id);

        // Настройка свойств
        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Description)
            .HasMaxLength(1000);

        builder.Property(p => p.Price)
            .IsRequired()
            .HasColumnType("decimal(18,2)"); // Точность для денежных значений

        builder.Property(p => p.Stock)
            .IsRequired();

        builder.Property(p => p.ImageUrl)
            .HasMaxLength(500);

        builder.Property(p => p.CreatedAt)
            .IsRequired();

        builder.Property(p => p.UpdatedAt);

        // Связь с Category (Many-to-One)
        builder.HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict); // Запрещаем каскадное удаление

        // Игнорируем доменные события (не сохраняем их в БД)
        builder.Ignore(p => p.DomainEvents);

        // Индексы для оптимизации запросов
        builder.HasIndex(p => p.CategoryId);
        builder.HasIndex(p => p.Name);
    }
}
