using nutriapp.core.Entities;
using System.Linq.Expressions;

namespace nutriapp.infrastructure.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    IQueryable<T> GetAll();
    IQueryable<T> GetAllIncluding(Expression<Func<T, object>> includeProperty);
    IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] navigationProperties);
    IQueryable<T> GetAllIncluding(params string[] navigationProperties);
    Task<T> GetByIdAsync(object id);
    Task AddAsync(T item);
    void Update(T item);
    Task DeleteAsync(object id);
}