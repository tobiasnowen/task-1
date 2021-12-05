using Infra.Storage.Entities;

namespace Infra.Storage;

public interface IDataBase
{
    Task AddDiscountCodeBatchAsync(DiscountCodeBatch batch, CancellationToken cancellationToken);
    Task<List<Brand>> GetBrandsAsync(CancellationToken cancellationToken);
    Task<List<DiscountCodeBatch>> GetDiscountCodeBatchesAsync(CancellationToken cancellationToken);
    Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);

}