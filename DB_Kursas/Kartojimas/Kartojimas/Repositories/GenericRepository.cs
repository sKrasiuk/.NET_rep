using System;
using System.Linq.Expressions;
using Kartojimas.Entities.Db;
using Kartojimas.Entities.Interfaces;
using Kartojimas.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Kartojimas.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly GenericDbContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(GenericDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<T>();
    }

    public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate);
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.AsEnumerable();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public int Save(T entity)
    {
        if (entity.Id == 0)
        {
            _dbSet.Add(entity);
        }
        else
        {
            _dbSet.Update(entity);
        }

        _dbContext.SaveChanges();
        return entity.Id;
    }
}
