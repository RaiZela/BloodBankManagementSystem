using System.Linq.Expressions;
using DAL.Data.Base.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;
namespace BloodBankManagementSystem.BLL;

public interface IRepository<TContext> where TContext : DbContext
{
    IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : class;
    bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class;
    TEntity Create<TEntity>(TEntity entity) where TEntity : class;
    Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class;
    void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    Task CreateRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    void Update<TEntity>(TEntity entity) where TEntity : class;
    void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    void Delete<TEntity>(int id) where TEntity : class;
    void Delete<TEntity>(string id) where TEntity : class;
    void Delete<TEntity>(TEntity entity) where TEntity : class;
    void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    Task<bool> SaveAsync(CancellationToken cancellationToken = default);

}
public class Repository<TContext> : IRepository<TContext> where TContext : DbContext
{
    private readonly ILogger _logger;
    protected readonly TContext _dbContext;

    public Repository(TContext context, TContext dbContext, ILogger logger)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    #region Get
    public virtual IQueryable<TEntity> GetQueryable<TEntity>(Expression<Func<TEntity, bool>>? filter = null) where TEntity : class
    {
        IQueryable<TEntity> query = _dbContext.Set<TEntity>();
        if (filter != null)
        {
            query = query.Where(filter);
        }
        return query;
    }

    public virtual bool Exists<TEntity>(Expression<Func<TEntity, bool>> filter = null) where TEntity : class
    {
        return GetQueryable(filter).Any();
    }

    #endregion Get

    #region Create
    public virtual TEntity Create<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            return _dbContext.Set<TEntity>().Add(entity).Entity;
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }
    }
    public virtual async Task<TEntity> CreateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            return (await _dbContext.Set<TEntity>().AddAsync(entity)).Entity;
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }
    }
    public virtual void CreateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            dbSet.AddRange(entities);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }

    }
    public virtual async Task CreateRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            await dbSet.AddRangeAsync(entities);
        }
        catch (Exception e)
        { _logger.Error(e, e.Message);
            throw;
        }

    }
    #endregion

    #region Update
    public virtual void Update<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }

    }
    public virtual void UpdateRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            dbSet.UpdateRange(entities);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }

    }
    #endregion

    #region Delete
    public virtual void Delete<TEntity>(int id) where TEntity : class
    {
        try
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message); 
            throw;
        }

    }

    public virtual void Delete<TEntity>(string id) where TEntity : class
    {
        try
        {
            TEntity entity = _dbContext.Set<TEntity>().Find(id);
            Delete(entity);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            throw;
        }

    }
    public virtual void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            throw;
        }

    }
    public virtual void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        try
        {
            var dbSet = _dbContext.Set<TEntity>();
            dbSet.RemoveRange(entities);
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            throw;
        }

    }
    #endregion

    #region Save
    //public virtual bool Save()
    //{
    //    try
    //    {
    //        //UpdateAuditFields();
    //        return _dbContext.SaveChanges() > 0;
    //    }
    //    catch (Exception e)
    //    {
    //        _logger.Error(e, e.Message);
    //        throw;
    //    }
    //}
    public virtual async Task<bool> SaveAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        }
        catch (Exception e)
        {
            _logger.Error(e, e.Message);
            throw;
        }
    }



    //private void UpdateAuditFields()
    //{
    //    var entries = _dbContext.ChangeTracker.Entries<AuditableEntity>();

    //    foreach (var entry in entries)
    //    {
    //        var now = DateTime.UtcNow;
    //        //var userName = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unknown";

    //        switch (entry.State)
    //        {
    //            case EntityState.Added:
    //                entry.Entity.CreatedDate = now;
    //                //entry.Entity.CreatedBy = userName;
    //                entry.Entity.LastUpdatedDate = now;
    //                //entry.Entity.LastUpdatedBy = userName;
    //                entry.Entity.IsDeleted = false;
    //                break;

    //            case EntityState.Modified:
    //                entry.Entity.LastUpdatedDate = now;
    //                //entry.Entity.LastUpdatedBy = userName;
    //                break;

    //            case EntityState.Deleted:
    //                entry.State = EntityState.Modified;
    //                entry.Entity.IsDeleted = true;
    //                entry.Entity.DeletedDate = now;
    //                //entry.Entity.DeletedBy = userName;
    //                break;
    //        }
    //    }
    //}

    #endregion
}