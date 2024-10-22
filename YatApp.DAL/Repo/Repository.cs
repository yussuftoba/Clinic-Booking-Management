using Data;
using Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System;
using System.Linq.Dynamic.Core;
namespace Repo;

public class Repository<T> : IRepository<T> where T : class
{
    protected VizeetaAppDbContext _context;
    public Repository(VizeetaAppDbContext context)
    {
        _context = context;
    }


    #region GetOneObject

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id);
    }


    public T Find(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.SingleOrDefault(criteria);
    }
    //public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    //{
    //    return _context.Where(predicate).ToList(); // This allows filtering based on conditions
    //}

    public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var incluse in includes)
                query = query.Include(incluse);

        return await query.SingleOrDefaultAsync(criteria);
    } 
    #endregion

    #region GetDataAscollection
    public IEnumerable<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }

    public List<string> GetDistinct(Expression<Func<T, string>> col)
    {
        var distinctValues = _context.Set<T>().Select(col).Distinct().ToList();
        return distinctValues;
    }
    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return query.Where(criteria).ToList();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int skip, int take)
    {
        return _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToList();
    }

    public IEnumerable<T> FindAll(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null, bool IsDesc = false)
    {
        IQueryable<T> query = _context.Set<T>().Where(criteria);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (orderBy != null)
        {
            if (!IsDesc)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);
        }

        return query.ToList();
    }
    /// <summary>
    /// usingf with Jquery datatable where user can filter using any criteria based on the model
    /// </summary>
    /// <param name="criteria">search criteria</param>
    /// <param name="sortColumn">column to sort</param>
    /// <param name="sortColumnDirection"> asc or desc</param>
    /// <param name="skip"> paging </param>
    /// <param name="take">no of records per time</param>
    /// <returns> data as josn</returns>
    public IEnumerable<T> FindWithFilters(Expression<Func<T, bool>> criteria = null, string sortColumn = null, string sortColumnDirection = null, int? skip = null, int? take = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (criteria != null)
            query = _context.Set<T>().Where(criteria);

        if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortColumnDirection))
        {
            query = query.OrderBy(string.Concat(sortColumn, " ", sortColumnDirection));
        }

        if (skip.HasValue)
        {
            query = query.Skip(skip.Value);
        }

        if (take.HasValue)
        {
            query = query.Take(take.Value);
        }

        return query.ToList();
    }


    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (includes != null)
            foreach (var include in includes)
                query = query.Include(include);

        return await query.Where(criteria).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
    {
        return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
    }

    public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip, Expression<Func<T, object>> orderBy = null, bool IsDesc = false)
    {
        IQueryable<T> query = _context.Set<T>().Where(criteria);

        if (take.HasValue)
            query = query.Take(take.Value);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (orderBy != null)
        {
            if (!IsDesc)
                query = query.OrderBy(orderBy);
            else
                query = query.OrderByDescending(orderBy);
        }

        return await query.ToListAsync();
    }

    #endregion

    #region Add_Update_Delete
    public T Add(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public async Task<T> AddAsync(T entity)
    {
        await _context.Set<T>().AddAsync(entity);
        return entity;
    }

    public IEnumerable<T> AddRange(IEnumerable<T> entities)
    {
        _context.Set<T>().AddRange(entities);
        return entities;
    }

    public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
        return entities;
    }

    public T Update(T entity)
    {
        _context.Update(entity);

        return entity;
    }
    public bool UpdateRange(IEnumerable<T> entities)
    {
        _context.UpdateRange(entities);

        return true;
    }
    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _context.Set<T>().RemoveRange(entities);
    } 
    #endregion

    #region Aggregate

    public int Count()
    {
        return _context.Set<T>().Count();
    }

    public int Count(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().Count(criteria);
    }

    public async Task<int> CountAsync()
    {
        return await _context.Set<T>().CountAsync();
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
    {
        return await _context.Set<T>().CountAsync(criteria);
    }
    public async Task<Int64> MaxAsync(Expression<Func<T, object>> column)
    {
        return Convert.ToInt64(await _context.Set<T>().MaxAsync(column));
    }
    public async Task<Int64> MaxAsync(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column)
    {
        return Convert.ToInt64(await _context.Set<T>().Where(criteria).MaxAsync(column));
    }
    public Int64 Max(Expression<Func<T, object>> column)
    {
        return Convert.ToInt64(_context.Set<T>().Max(column));
    }
    public Int64 Max(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> column)
    {
        return Convert.ToInt64(_context.Set<T>().Where(criteria).Max(column));
    }
    public bool IsExist(Expression<Func<T, bool>> criteria)
    {
        return _context.Set<T>().Any(criteria);
    }
    public T Last(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> orderBy)
    {
        return _context.Set<T>().OrderByDescending(orderBy).FirstOrDefault(criteria);
    } 
    #endregion
}
