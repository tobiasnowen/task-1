namespace Domain.Services;

public class GenerateDiscountBatchArgs
{
    public int BatchSize { get; init; }
    public string? Oid { get; init; }
    public string? Name { get; init; }
}