using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория для Product
/// Расширяет базовый репозиторий специфичными методами
/// </summary>
public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(CatalogDbContext context) : base(context)
    {
    }

    /// <summary>
    /// Получить все продукты с включением данных о категории (Eager Loading)
    /// </summary>
    public override async Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.Category) // Загружаем связанную категорию
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Получить продукты по категории
    /// </summary>
    public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(
        Guid categoryId,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Where(p => p.CategoryId == categoryId)
            .ToListAsync(cancellationToken);
    }

    /// <summary>
    /// Поиск продуктов по названию или описанию
    /// </summary>
    public async Task<IEnumerable<Product>> SearchProductsAsync(
        string searchTerm,
        CancellationToken cancellationToken = default)
    {
        return await _dbSet
            .Include(p => p.Category)
            .Where(p => p.Name.Contains(searchTerm) || p.Description.Contains(searchTerm))
            .ToListAsync(cancellationToken);
    }
}
