namespace Catalog.Application.Interfaces;

/// <summary>
/// Unit of Work паттерн
/// Координирует работу нескольких репозиториев и обеспечивает транзакционность
/// </summary>
public interface IUnitOfWork : IDisposable
{
    IProductRepository Products { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
