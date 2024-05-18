
namespace Library.Model;

public class Shelf : BaseModel
{
    public required Bookshelf Bookshelf { get; set; }
    public int? MaxCapacityOfBooks { get; set; }
    public ICollection<BookEdition> BookEditions { get; } = [];
}