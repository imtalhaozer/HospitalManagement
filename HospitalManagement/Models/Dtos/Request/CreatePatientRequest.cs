namespace HospitalManagement.Models.Dtos.Request;

public record CreatePatientRequest(string Name, string Surname, int TurkishId,int DoctorId);