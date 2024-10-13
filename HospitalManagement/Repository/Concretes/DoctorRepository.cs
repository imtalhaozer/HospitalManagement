using HospitalManagement.Contexts;
using HospitalManagement.Models;
using HospitalManagement.Repository.Abstracts;

namespace HospitalManagement.Repository.Concretes;

public class DoctorRepository : BaseRepository<Doctor,int>
{
    public DoctorRepository(MsSqlContext context) : base(context)
    {
    }
    
    public Doctor? GetById(int id)
    {
        Doctor? entity= Context.Set<Doctor>().Find(id);
        return entity;
    }

    public List<Doctor> GetAll()
    {
        List<Doctor> entities = Context.Set<Doctor>().ToList();
        return entities;
    }
}