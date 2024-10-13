using HospitalManagement.Exceptions;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Repository.Concretes;

namespace HospitalManagement.Validation;

public class AppoinmentValidator()
{
    private readonly AppoinmentRepository _appoinmentRepository;

    public AppoinmentValidator(AppoinmentRepository appoinmentRepository):this()
    {
        _appoinmentRepository = appoinmentRepository;
    }

    public void ValidateAppoinment(CreateAppoinmentRequest newObject)
    {
        if (newObject.AppoinmentDate.Day <= DateTime.Now.Day + 3)
        {
            throw new AppointmentNotAvailableException("Invalid day");
        }

        if (_appoinmentRepository.GetAppoinmentByDateAndDoctorId(newObject.AppoinmentDate, newObject.DoctorId) != null)
        {
            throw new AppointmentDateAlreadyExistsException("Appoinment date already exists");
        }

        if (_appoinmentRepository.GetAppoinmentCountByDoctorId(newObject.DoctorId)>10)
        {
            throw new InvalidAppointmentDayException("Appoinment not avaible");
        }
    }
}