using FluentValidation;
using MediatR;

namespace Catalog.Application.Behaviors;

/// <summary>
/// Pipeline Behavior для автоматической валидации всех команд и запросов
/// Это middleware, который выполняется перед каждым Handler'ом
/// </summary>
public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        // Если нет валидаторов, просто передаем управление дальше
        if (!_validators.Any())
        {
            return await next();
        }

        // Создаем контекст валидации
        var context = new ValidationContext<TRequest>(request);

        // Запускаем все валидаторы
        var validationResults = await Task.WhenAll(
            _validators.Select(v => v.ValidateAsync(context, cancellationToken)));

        // Собираем все ошибки
        var failures = validationResults
            .SelectMany(r => r.Errors)
            .Where(f => f != null)
            .ToList();

        // Если есть ошибки, выбрасываем исключение
        if (failures.Count != 0)
        {
            throw new ValidationException(failures);
        }

        // Если валидация прошла успешно, передаем управление следующему обработчику
        return await next();
    }
}
