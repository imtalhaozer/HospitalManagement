using HospitalManagement.Contexts;
using HospitalManagement.Models;

namespace HospitalManagement.Repository.Abstracts;

public abstract class BaseRepository<TEntity,TId> : IRepository<TEntity,TId> where TEntity : Entity<TId>,new() 
{
    protected readonly MsSqlContext Context;

    public BaseRepository(MsSqlContext context)
    {
        Context = context;
    }

    public TEntity Add(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
        Context.SaveChanges();
        return entity;
    }

    public TEntity Update(TEntity entity)
    {
        Context.Set<TEntity>().Update(entity);
        Context.SaveChanges();
        return entity;
    }
    

    public TEntity Remove(TEntity entity)
    {
        Context.Set<TEntity>().Remove(entity);
        Context.SaveChanges();
        return entity;
    }
}