using HospitalManagement.Models;

namespace HospitalManagement.Repository.Abstracts;

public interface IAppoinmentRepository
{ 
    Appoinment? GetAppoinmentByDateAndDoctorId(DateTime appoinmentDate, int doctorId);
    int GetAppoinmentCountByDoctorId(int doctorId);
}