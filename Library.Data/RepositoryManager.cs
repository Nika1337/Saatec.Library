

namespace Library.Data;

public class RepositoryManager(RepositoryContext repositoryContext) : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext = repositoryContext;

    public async Task SaveAsync() => await _repositoryContext.SaveChangesAsync();
}
