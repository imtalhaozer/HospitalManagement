namespace HospitalManagement.Models.Dtos.Request;

public record CreateAppoinmentRequest(DateTime AppoinmentDate, int DoctorId, int PatientId);