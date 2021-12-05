namespace Domain.Models;

public class DiscountCode
{
    public string? Id { get; set; }
    public bool Claimed { get; set; }
    public string? ClaimedBy { get; set; }
    public bool Redeemed { get; set; }
    public string? RedeemedBy { get; set; }
}