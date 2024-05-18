
namespace Library.Model;

public class Room : BaseModel
{
    public int Floor { get; set; }
    public int RoomNumber { get; set; }
    public int? MaxCapacityOfPeople { get; set; }
    public ICollection<Bookshelf> Bookshelves { get; } = [];
}