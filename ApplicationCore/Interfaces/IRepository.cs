using Ardalis.Specification;
using Nika1337.Library.ApplicationCore.Entities;

namespace Nika1337.Library.ApplicationCore.Interfaces;

public interface IRepository<T> : IRepositoryBase<T> where T : BaseModel {

}