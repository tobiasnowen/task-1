namespace Infra.Storage.Entities;

public class DiscountCode
{
    public string? Id { get; init; }
    public bool Claimed { get; set; }
    public string? ClaimedBy { get; set; }
    public bool Redeemed { get; set; }
    public string? RedeemedBy { get; set; }
}