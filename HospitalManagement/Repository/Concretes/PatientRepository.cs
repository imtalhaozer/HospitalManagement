using HospitalManagement.Contexts;
using HospitalManagement.Models;
using HospitalManagement.Repository.Abstracts;

namespace HospitalManagement.Repository.Concretes;

public class PatientRepository : BaseRepository<Patient,int>
{
    public PatientRepository(MsSqlContext context) : base(context)
    {
    }
    
    public Patient? GetById(int id)
    {
        Patient? entity= Context.Set<Patient>().Find(id);
        return entity;
    }

    public List<Patient> GetAll()
    {
        List<Patient> entities = Context.Set<Patient>().ToList();
        return entities;
    }
}