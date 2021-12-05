using Domain.Services;
using Infra.Storage.Entities;
using DiscountCode = Domain.Models.DiscountCode;

namespace Infra.Storage.Adapter;

public class DiscountCodesAdapter : IDiscountCodesAdapter
{
    private readonly IDataBase _dataBase;

    public DiscountCodesAdapter(IDataBase dataBase) => _dataBase = dataBase;

    public async Task<string?> GenerateDiscountCodeBatchAsync(
        GenerateDiscountBatchArgs args, CancellationToken cancellationToken)
    {
        var brands = await _dataBase.GetBrandsAsync(cancellationToken);
        var brand = brands.Single(x => x.Oid == args.Oid);

        var codes = Enumerable.Range(1, args.BatchSize)
            .Select(_ => new Entities.DiscountCode { Id = Guid.NewGuid().ToString() })
            .ToList();

        var batch = new DiscountCodeBatch
        {
            Active = true,
            Id = Guid.NewGuid().ToString(),
            Name = args.Name,
            DiscountCodes = codes,
            Brand = brand
        };

        await _dataBase.AddDiscountCodeBatchAsync(batch, cancellationToken);

        return batch.Id;
    }

    public async Task<DiscountCode?> GetDiscountCodeAsync(GetDiscountCodeArgs args, CancellationToken cancellationToken)
    {
        var users = await _dataBase.GetUsersAsync(cancellationToken);
        var user = users.FirstOrDefault(x => x.Id == args.UserId);
        if (user == null) return null;

        var batches = await _dataBase.GetDiscountCodeBatchesAsync(cancellationToken);
        var batch = batches.FirstOrDefault(x => x.Id == args.BatchId && x.Active);

        var discountCode = batch?.DiscountCodes?.FirstOrDefault(x => !x.Claimed);
        if (discountCode == null) return null;

        discountCode.Claimed = true;
        discountCode.ClaimedBy = user.Id;

        // TODO: notify brand

        return new DiscountCode
        {
            Id = discountCode.Id,
            Claimed = discountCode.Claimed,
            ClaimedBy = discountCode.ClaimedBy,
        };
    }
}