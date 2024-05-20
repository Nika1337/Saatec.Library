
namespace Nika1337.Library.ApplicationCore.Entities;

public class Address
{
    public required string Street { get; set; }
    public required string City { get; set; }
    public string? State { get; set; }
    public required string Country { get; set; }
    public string? PostalCode { get; set; }
}