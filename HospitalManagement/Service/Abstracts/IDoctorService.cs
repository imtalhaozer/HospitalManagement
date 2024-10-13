using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Abstracts;

public interface IDoctorService : IService<Doctor,int,DoctorResponseDto,CreateDoctorRequest>
{

}