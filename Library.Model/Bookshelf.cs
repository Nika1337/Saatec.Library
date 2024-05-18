

namespace Library.Model;

public class Bookshelf : BaseModel
{
    public required Room Room { get; set; }
    public int SectionId { get; set; }
    public ICollection<Shelf> Shelves { get; } = [];
}