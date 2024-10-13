using HospitalManagement.Contexts;
using HospitalManagement.Models;
using HospitalManagement.Repository.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Repository.Concretes;

public class AppoinmentRepository : BaseRepository<Appoinment,Guid> ,IAppoinmentRepository
{
    private readonly MsSqlContext  _context;

    public AppoinmentRepository(MsSqlContext context) : base(context)
    {
        _context = context;
    }


    public Appoinment? GetAppoinmentByDateAndDoctorId(DateTime appoinmentDate, int doctorId)
    {
        Appoinment? appoinment = _context.Set<Appoinment>()
            .FirstOrDefault(x => x.AppoinmentDate == appoinmentDate && x.DoctorId == doctorId);
        return appoinment;
    }
    
    public Appoinment? GetById(Guid id)
    {
        Appoinment? entity=
            _context.Set<Appoinment>()
                .Include(x=>x.Doctor)
                .Include(x=>x.Patient)
                .SingleOrDefault(x=>x.Id == id);
        return entity;
    }

    public List<Appoinment> GetAll()
    {
        List<Appoinment> entities = _context.Set<Appoinment>()
            .Include(x=>x.Doctor)
            .Include(x=>x.Patient)
            .ToList();
        return entities;
    }

    public int GetAppoinmentCountByDoctorId(int doctorId)
    {
        int appoinmentCount = _context.Set<Appoinment>().Count(x => x.DoctorId == doctorId);
        return appoinmentCount;
    }
}