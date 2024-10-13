namespace HospitalManagement.Models;

public class Patient : Entity<int>
{
    public Patient()
    {
        Name = string.Empty;
        Surname = string.Empty;
    }

    public Patient(string name, string surname, int turkishId, int doctorId, Doctor doctor, List<Appoinment> appoinments)
    {
        Name = name;
        Surname = surname;
        TurkishId = turkishId;
        DoctorId = doctorId;
        Doctor = doctor;
        Appoinments = appoinments;
    }
    
    public string Name { get; set; }
    public string Surname { get; set; }
    public int TurkishId { get; set; }
    public int DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public List<Appoinment> Appoinments { get; set; }
}