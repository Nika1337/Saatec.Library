
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Library.Model;

namespace Library.Data.Repositories;

public class RepositoryBase<T> : IRepositoryBase<T> where T : BaseModel
{
    private readonly RepositoryContext _repositoryContext;

    protected RepositoryBase(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
    }
    public IQueryable<T> GetAll(bool trackChanges) => trackChanges ? _repositoryContext.Set<T>() : _repositoryContext.Set<T>().AsNoTracking();


    public IQueryable<T> GetByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
    {
        return trackChanges? _repositoryContext.Set<T>().Where(condition) : _repositoryContext.Set<T>().Where(condition).AsNoTracking();
    }

    public void Create(T model) => _repositoryContext.Set<T>().Add(model);

    public void Updated(T model) => _repositoryContext.Set<T>().Update(model);
    public void Delete(T model) => _repositoryContext.Set<T>().Remove(model);
}
