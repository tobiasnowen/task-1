using MediatR;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Infra.Storage.Cqrs;

public class GenerateDiscountCodesCommand : IRequest<string>
{
    public string? Oid { get; init; }
    public int BatchSize { get; init; }
    public string? Name { get; init; }
}