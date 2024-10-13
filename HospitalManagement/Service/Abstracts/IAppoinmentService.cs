using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Abstracts;

public interface IAppoinmentService : IService<ReturnModel<Appoinment>,Guid,ReturnModel<AppoinmentResponseDto>,CreateAppoinmentRequest>
{
    ReturnModel<Appoinment> OutdatedAppointment();
}