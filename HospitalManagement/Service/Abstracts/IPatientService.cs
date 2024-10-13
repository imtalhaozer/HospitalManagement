using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Abstracts;

public interface IPatientService : IService<Patient,int,PatientResponseDto,CreatePatientRequest>
{
    
}