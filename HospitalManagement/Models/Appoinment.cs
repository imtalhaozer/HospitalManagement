namespace HospitalManagement.Models;

public class Appoinment : Entity<Guid>
{
    public Appoinment()
    {
        CreatedDate = DateTime.Now;
    }

    public Appoinment(DateTime appoinmentDate,int doctorId, int patientId):this()
    {
        AppoinmentDate = appoinmentDate;
        DoctorId = doctorId;
        PatientId = patientId;
    }
    
    private int doctorId;
    private int patientId;
    public DateTime AppoinmentDate { get; set; }
    public DateTime CreatedDate { get; set; }

    public int DoctorId
    {
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Doctor id cannot be less than 0");
            }
            doctorId = value;
        }

        get
        {
            return doctorId;
        }
    }
    public Doctor Doctor { get; set; }

    public int PatientId
    {
        set
        {
            if (value<0)
            {
                throw new ArgumentException("Patinet id cannot be less than 0");
            }
            patientId = value;
        }

        get
        {
            return patientId;
        }
    }
    public Patient Patient { get; set; }
}