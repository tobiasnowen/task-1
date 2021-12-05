using Domain.Models;

namespace Domain.Services;

public interface IDiscountCodesAdapter
{
    Task<string?> GenerateDiscountCodeBatchAsync(GenerateDiscountBatchArgs args, CancellationToken cancellationToken);
    Task<DiscountCode?> GetDiscountCodeAsync(GetDiscountCodeArgs args, CancellationToken cancellationToken);
}