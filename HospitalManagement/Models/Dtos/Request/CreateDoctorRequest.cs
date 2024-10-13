namespace HospitalManagement.Models.Dtos.Request;

public record CreateDoctorRequest
    (
        string Name,
        string Surname,
        DoctorBranch Branch
    );