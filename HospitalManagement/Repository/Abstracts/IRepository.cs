using HospitalManagement.Models;

namespace HospitalManagement.Repository.Abstracts;

public interface IRepository<TEntity,TId>
{
   TEntity Add(TEntity entity);
   TEntity Update(TEntity entity);
   TEntity Remove(TEntity entity);
}