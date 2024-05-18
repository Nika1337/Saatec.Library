
namespace Library.Model;

public class PersonalAccount : Account
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string IdNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
}