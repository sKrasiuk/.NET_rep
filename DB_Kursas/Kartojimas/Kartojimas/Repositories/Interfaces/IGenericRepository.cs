using System;
using System.Linq.Expressions;
using Kartojimas.Entities.Interfaces;

namespace Kartojimas.Repositories.Interfaces;

public interface IGenericRepository<T> where T : class, IEntity
{
    public T GetById(int id);
    public IEnumerable<T> GetAll();
    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
    public int Save(T entity);
}
