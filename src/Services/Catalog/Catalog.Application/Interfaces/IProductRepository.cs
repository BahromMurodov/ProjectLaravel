using Catalog.Domain.Entities;

namespace Catalog.Application.Interfaces;

/// <summary>
/// Интерфейс репозитория для работы с продуктами
/// Расширяет базовый репозиторий специфичными методами
/// </summary>
public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId, CancellationToken cancellationToken = default);
    Task<IEnumerable<Product>> SearchProductsAsync(string searchTerm, CancellationToken cancellationToken = default);
}
