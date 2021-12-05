using Domain.Models;
using MediatR;

namespace Infra.Storage.Cqrs;

public class GetDiscountCodeQuery : IRequest<DiscountCode?>
{
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? Oid { get; init; }
    
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public string? UserId { get; init; }
}