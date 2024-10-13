using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Mappers;

public class PatientMapper
{
    public Patient ConvertToEntity(CreatePatientRequest createDoctorRequest)
    {
        return new Patient()
        {
            Name = createDoctorRequest.Name,
            Surname = createDoctorRequest.Surname,
            TurkishId = createDoctorRequest.TurkishId,
            DoctorId = createDoctorRequest.DoctorId,
        };
    }

    public PatientResponseDto ConvertToResponse(Patient patient)
    {
        return new PatientResponseDto
        (
            Name:patient.Name,
            Surname:patient.Surname
        );
    }
}