

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nika1337.Library.ApplicationCore.Entities;
using Nika1337.Library.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Data;

public class EfRepository<T>(DbContext dbContext) : LibraryRepositoryBase<T>(dbContext), IReadRepository<T>, IRepository<T> where T : BaseModel
{

}
