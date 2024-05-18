

namespace Library.Model;

public class Genre : BaseModel
{
    public required string Name { get; set; }
    public string? Description { get; set; }
}