
namespace Library.Model;

public class CompanyAccount : Account
{
    public required string CompanyName { get; set; }
    public string? WebsiteAddress { get; set; }
}
