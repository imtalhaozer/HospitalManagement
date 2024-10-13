namespace HospitalManagement.Models;

public class Doctor : Entity<int>
{
    public Doctor()
    {
        Branch = DoctorBranch.Cardiology;
        Patients = new List<Patient>();
        Appoinments = new List<Appoinment>();
    }

    public Doctor(string name, string surname, DoctorBranch branch,List<Patient> patients,List<Appoinment> appoinments)
    {
        Name = name;
        Surname = surname;
        Branch = branch;
        Patients = patients;
        Appoinments = appoinments;
    }

    private string name;
    private string surname;
    public string Name
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException("Name cannot be null or empty");
            }
            name = value;
        }

        get
        {
            return name;
        }
    }

    public string Surname
    {
        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new NullReferenceException("Surname cannot be null or empty");
            }
            surname = value;
        }

        get
        {
            return surname;
        }
    }
    public DoctorBranch Branch { get; set; }
    public List<Patient> Patients { get; set; }
    public List<Appoinment> Appoinments { get; set; }
}