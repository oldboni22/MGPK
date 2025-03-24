using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Repository;


public interface IRepositoryBase<T>
{
    public IQueryable<T> FindAll(bool trackChanges);
    public IQueryable<T> FindByCondition(Expression<Func<T,bool>> condition,bool trackChanges);

    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);

}

public abstract class RepositoryBase<T>(RepositoryContext context) : IRepositoryBase<T> where T : class
{
    protected readonly RepositoryContext _context = context;
    
    public IQueryable<T> FindAll(bool trackChanges)
    {
        return trackChanges ? _context.Set<T>() : _context.Set<T>().AsNoTracking();
    }

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition, bool trackChanges)
    {
        var matches = _context.Set<T>().Where(condition);
        return trackChanges ? matches : matches.AsNoTracking();
    }

    public void Create(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Update(T entity)
    {
        _context.Set<T>().Update(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }
}