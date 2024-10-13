namespace HospitalManagement.Models.Dtos.Response;

public record AppoinmentResponseDto(DateTime AppoinmentDate, string DoctorName, string PatientName);