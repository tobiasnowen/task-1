namespace Infra.Storage.Entities;

public class DiscountCodeBatch
{
    public Brand? Brand { get; init; }
    public List<DiscountCode>? DiscountCodes { get; init; }

    public bool Active { get; init; }
    public string? DisplayName { get; set; }
    public string? Id { get; init; }
    public string? Name { get; set; }
}