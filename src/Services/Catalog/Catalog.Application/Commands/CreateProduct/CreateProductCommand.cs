using Catalog.Application.Common;
using Catalog.Application.DTOs;
using MediatR;

namespace Catalog.Application.Commands.CreateProduct;

/// <summary>
/// Команда для создания нового продукта (CQRS Command)
/// Реализует IRequest<T> от MediatR
/// </summary>
public record CreateProductCommand(
    string Name,
    string Description,
    decimal Price,
    int Stock,
    string ImageUrl,
    Guid CategoryId) : IRequest<Result<ProductDto>>;
