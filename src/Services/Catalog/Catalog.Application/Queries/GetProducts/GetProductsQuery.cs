using Catalog.Application.DTOs;
using MediatR;

namespace Catalog.Application.Queries.GetProducts;

/// <summary>
/// Запрос для получения списка всех продуктов (CQRS Query)
/// Queries только читают данные, не изменяя состояние системы
/// </summary>
public record GetProductsQuery : IRequest<IEnumerable<ProductDto>>;
