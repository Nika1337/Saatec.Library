
namespace Library.Model;

public abstract class BaseModel
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdatedDate { get; set; }
    public DateTime? DeletedDate { get; set; }
    public string? LastModifiedBy { get; set; }
}
