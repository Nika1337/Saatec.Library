
namespace Library.Model;

public class Publisher : BaseModel
{
    public required string PublisherName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
    public string? WebsiteAddress { get; set; }
    public ICollection<BookEdition> PublishedBooks { get; } = [];
}