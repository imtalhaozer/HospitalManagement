using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;

namespace HospitalManagement.Service.Mappers;

public class AppoinmentMapper
{
    public Appoinment ConvertToEntity(CreateAppoinmentRequest request)
    {
        return new Appoinment()
        {
            AppoinmentDate = request.AppoinmentDate,
            DoctorId = request.DoctorId,
            PatientId = request.PatientId,
        };
    }

    public AppoinmentResponseDto ConvertToResponse(Appoinment appoinment)
    {
        return new AppoinmentResponseDto
        (
           AppoinmentDate:appoinment.AppoinmentDate,
           DoctorName:appoinment.Doctor.Name,
           PatientName:appoinment.Patient.Name
        );
    }
}