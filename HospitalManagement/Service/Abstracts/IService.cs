using Azure;
using Azure.Core;
using HospitalManagement.Models;

namespace HospitalManagement.Service.Abstracts;

public interface IService<TEntity,TId,TResponse,TRequest> 
    where TEntity : Entity<TId>, new()
{
    TEntity Add(TRequest newObject);
    TEntity Update(TRequest newObject);
    TResponse GetById(TId id);
    List<TResponse> GetAll();
    TEntity Delete(TId id);
}