using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Catalog.Infrastructure.Data;

/// <summary>
/// DbContext для Catalog сервиса
/// Управляет подключением к базе данных и таблицами
/// </summary>
public class CatalogDbContext : DbContext
{
    public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
    {
    }

    // DbSets - представляют таблицы в базе данных
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Автоматически применяем все конфигурации из этой сборки
        // Конфигурации находятся в папке Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Переопределяем SaveChanges для обработки доменных событий
    /// </summary>
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // Здесь можно добавить логику для:
        // - Автоматического заполнения CreatedAt/UpdatedAt
        // - Публикации доменных событий
        // - Аудита изменений

        return await base.SaveChangesAsync(cancellationToken);
    }
}
