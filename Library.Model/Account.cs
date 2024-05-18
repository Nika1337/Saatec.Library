
namespace Library.Model;

public abstract class Account : BaseModel
{
    public required string AccountName { get; set; }
    public DateTime AccountCreationDate { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required string Address { get; set; }
}
