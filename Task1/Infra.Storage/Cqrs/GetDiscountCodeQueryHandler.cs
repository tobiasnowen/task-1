using Domain.Models;
using Domain.Services;
using MediatR;

namespace Infra.Storage.Cqrs;

public class GetDiscountCodeQueryHandler : IRequestHandler<GetDiscountCodeQuery, DiscountCode?>
{
    private readonly IDiscountCodesAdapter _adapter;

    public GetDiscountCodeQueryHandler(IDiscountCodesAdapter adapter) => _adapter = adapter;

    public Task<DiscountCode?> Handle(GetDiscountCodeQuery request, CancellationToken cancellationToken)
    {
        var args = new GetDiscountCodeArgs
        {
            BatchId = request.Oid,
            UserId = request.UserId
        };
        
        return _adapter.GetDiscountCodeAsync(args, cancellationToken);
    }
}