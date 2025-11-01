using Catalog.Application.Commands.CreateProduct;
using Catalog.Application.Queries.GetProducts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

/// <summary>
/// API контроллер для управления продуктами
/// Демонстрирует использование CQRS с MediatR
/// </summary>
[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<ProductsController> _logger;

    public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Получить все продукты (CQRS Query)
    /// </summary>
    /// <returns>Список всех продуктов</returns>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Getting all products");

        // Отправляем Query через MediatR
        var products = await _mediator.Send(new GetProductsQuery(), cancellationToken);

        return Ok(products);
    }

    /// <summary>
    /// Создать новый продукт (CQRS Command)
    /// </summary>
    /// <param name="command">Данные для создания продукта</param>
    /// <returns>Созданный продукт</returns>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateProduct(
        [FromBody] CreateProductCommand command,
        CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new product: {ProductName}", command.Name);

        // Отправляем Command через MediatR
        // Валидация автоматически выполняется через ValidationBehavior
        var result = await _mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
        {
            return BadRequest(new { error = result.Error });
        }

        return CreatedAtAction(
            nameof(GetProducts),
            new { id = result.Value!.Id },
            result.Value);
    }

    /// <summary>
    /// Health check endpoint
    /// </summary>
    [HttpGet("health")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "healthy", service = "catalog-api", timestamp = DateTime.UtcNow });
    }
}
