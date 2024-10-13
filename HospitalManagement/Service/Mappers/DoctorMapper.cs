using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Mappers;

public class DoctorMapper
{
    public Doctor ConvertToEntity(CreateDoctorRequest request)
    {
        return new Doctor()
        {
            Name = request.Name,
            Surname = request.Surname,
            Branch = request.Branch
        };
    }

    public DoctorResponseDto ConvertToResponse(Doctor doctor)
    {
        return new DoctorResponseDto
        (
            Id : doctor.Id,
            Name : doctor.Name,
            Surname : doctor.Surname,
            Branch : doctor.Branch
        );
    }
}