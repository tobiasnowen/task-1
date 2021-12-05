using Infra.Storage.Entities;

namespace Infra.Storage;

public class InMemoryDataBase : IDataBase
{
    private readonly List<Brand> _brands;
    private readonly List<DiscountCodeBatch> _discountCodeBatches;
    private readonly List<User> _users;

    public InMemoryDataBase()
    {
        _discountCodeBatches = new List<DiscountCodeBatch>();
        _brands = new List<Brand>
        {
            new()
            {
                Id = Guid.NewGuid().ToString(),
                Oid = "BrandId",
                DisplayName = "[Brand]",
                LegalName = "[Brand Inc.]"
            }
        };
        _users = new List<User>
        {
            new()
            {
                Id = "UserId",
                Address = "[Address]",
                Country = "[Country]",
                Email = "[Email]",
                FirstName = "[FirstName]",
                LastName = "[LastName]"
            }
        };
    }

    public Task<List<DiscountCodeBatch>> GetDiscountCodeBatchesAsync(CancellationToken cancellationToken) =>
        Task.FromResult(_discountCodeBatches);

    public Task<List<Brand>> GetBrandsAsync(CancellationToken cancellationToken) =>
        Task.FromResult(_brands);

    public Task<List<User>> GetUsersAsync(CancellationToken cancellationToken) =>
        Task.FromResult(_users);

    public Task AddDiscountCodeBatchAsync(DiscountCodeBatch batch, CancellationToken cancellationToken)
    {
        _discountCodeBatches.Add(batch);
        return Task.CompletedTask;
    }
}