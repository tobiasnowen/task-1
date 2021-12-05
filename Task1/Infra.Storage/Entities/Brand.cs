namespace Infra.Storage.Entities;

public class Brand
{
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? LegalName { get; set; }
    public string? Oid { get; init; }
}