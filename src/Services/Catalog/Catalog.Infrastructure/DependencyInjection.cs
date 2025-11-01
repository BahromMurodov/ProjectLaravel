using Catalog.Application.Interfaces;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure;

/// <summary>
/// Регистрация зависимостей Infrastructure слоя
/// Настраивает DbContext, репозитории и другие инфраструктурные сервисы
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // Регистрация DbContext с SQL Server
        services.AddDbContext<CatalogDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("CatalogDb"),
                b => b.MigrationsAssembly(typeof(CatalogDbContext).Assembly.FullName)
            )
        );

        // Регистрация репозиториев
        services.AddScoped<IProductRepository, ProductRepository>();

        // Регистрация Unit of Work
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
