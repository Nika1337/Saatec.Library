
namespace Library.Model;

public class BookCopy : BaseModel
{
    public required BookEdition BookEdition { get; set; }
    public required BookCopyCondition BookCopyCondition { get; set; }
}

public enum BookCopyCondition
{
    NeedsRestoration,
    Usable,
    LostByLibrary
}