

using System.Linq.Expressions;

namespace Library.Data.Repositories;

public interface IRepositoryBase<T> where T : class
{
    IQueryable<T> GetAll(bool trackChanges);
    IQueryable<T> GetByCondition(
        Expression<Func<T, bool>> condition,
        bool trackChanges
        );

    void Create(T model);
    void Updated(T model);
    void Delete(T model);
}