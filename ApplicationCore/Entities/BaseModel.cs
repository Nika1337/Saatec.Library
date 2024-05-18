using System;

namespace Nika1337.Library.ApplicationCore.Entities;

public abstract class BaseModel
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime LastUpdatedDate { get; set; } 
    public DateTime? DeletedDate { get; set; }
}
