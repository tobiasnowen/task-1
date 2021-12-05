using Domain.Services;
using MediatR;

namespace Infra.Storage.Cqrs;

public class
    GenerateDiscountCodesCommandHandler : IRequestHandler<GenerateDiscountCodesCommand, string?>
{
    private readonly IDiscountCodesAdapter _adapter;

    public GenerateDiscountCodesCommandHandler(IDiscountCodesAdapter adapter) => _adapter = adapter;

    public async Task<string?> Handle(GenerateDiscountCodesCommand request,
        CancellationToken cancellationToken)
    {
        var args = new GenerateDiscountBatchArgs
        {
            BatchSize = request.BatchSize,
            Name = request.Name!,
            Oid = request.Oid
        };

        return await _adapter.GenerateDiscountCodeBatchAsync(args, cancellationToken);
    }
}