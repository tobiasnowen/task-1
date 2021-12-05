namespace Api.OutputDto;

public class GetDiscountCodeOutputDto
{
    public string? Id { get; set; }
    public bool Claimed { get; set; }
    public string? ClaimedBy { get; set; }
}