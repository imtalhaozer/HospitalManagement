using System.Net;

namespace HospitalManagement.Models;

public class ReturnModel<TEntity> : Entity<Guid>
{
    public ReturnModel()
    {
        
    }

    public ReturnModel(bool success, string message, TEntity data, HttpStatusCode code)
    {
        Success = success;
        Message = message;
        Data = data;
        Code = code;
    }

    public bool Success { get; set; }
    public string Message { get; set; }
    public TEntity Data { get; set; }
    public HttpStatusCode Code { get; set; }
}