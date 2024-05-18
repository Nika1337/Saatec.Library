using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;
using System.Linq;

namespace Nika1337.Library.ApplicationCore;

public sealed class NonDeletedEntities<T> : Specification<T> where T : BaseModel
{
    public NonDeletedEntities() {
        Query
            .Where(bm => bm.DeletedDate != null);
    }
}
