using Catalog.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Catalog.Application;

/// <summary>
/// Класс для регистрации зависимостей Application слоя
/// Регистрирует MediatR, FluentValidation и другие сервисы
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Регистрация MediatR
        // Сканирует сборку и регистрирует все Handler'ы автоматически
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        // Регистрация всех валидаторов FluentValidation из этой сборки
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        // Регистрация Pipeline Behaviors
        // Эти behaviors будут выполняться для всех команд и запросов
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        return services;
    }
}
