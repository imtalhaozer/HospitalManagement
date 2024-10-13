using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;
using HospitalManagement.Repository.Concretes;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Mappers;

namespace HospitalManagement.Service.Concretes;

public class DoctorService(DoctorRepository doctorRepository,DoctorMapper doctorMapper) : IDoctorService
{
    public Doctor Add(CreateDoctorRequest newObject)
    {
        Doctor doctorObject=doctorMapper.ConvertToEntity(newObject);
        doctorRepository.Add(doctorObject);
        return doctorObject;
    }

    public Doctor Update(CreateDoctorRequest newObject)
    {
        Doctor doctorObject = doctorMapper.ConvertToEntity(newObject);
        doctorRepository.Update(doctorObject);
        return doctorObject;
    }

    public DoctorResponseDto GetById(int id)
    {
        Doctor? doctor=doctorRepository.GetById(id);
        DoctorResponseDto doctorObject= doctorMapper.ConvertToResponse(doctor);
        return doctorObject;
    }

    public List<DoctorResponseDto> GetAll()
    {
        List<Doctor> doctorList= doctorRepository.GetAll();
        List<DoctorResponseDto> doctorResponses = doctorList.Select(x => doctorMapper.ConvertToResponse(x)).ToList();
        return doctorResponses;
    }

    public Doctor Delete(int id)
    {
        Doctor? doctor = doctorRepository.GetById(id);
        doctorRepository.Remove(doctor);
        return doctor;
    }
}