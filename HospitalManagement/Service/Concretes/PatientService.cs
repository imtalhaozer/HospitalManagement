using HospitalManagement.Models;
using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Models.Dtos.Response;
using HospitalManagement.Repository.Concretes;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Mappers;

namespace HospitalManagement.Service.Concretes;

public class PatientService(PatientRepository patientRepository,PatientMapper patientMapper) : IPatientService
{
    public Patient Add(CreatePatientRequest newObject)
    {
        Patient patientObject=patientMapper.ConvertToEntity(newObject);
        patientRepository.Add(patientObject);
        return patientObject;
    }

    public Patient Update(CreatePatientRequest newObject)
    {
        Patient patientObject = patientMapper.ConvertToEntity(newObject);
        patientRepository.Update(patientObject);
        return patientObject;
    }

    public PatientResponseDto GetById(int id)
    {
        Patient? patient=patientRepository.GetById(id);
        PatientResponseDto patientObject= patientMapper.ConvertToResponse(patient);
        return patientObject;
    }

    public List<PatientResponseDto> GetAll()
    {
        List<Patient> patientList= patientRepository.GetAll();
        List<PatientResponseDto> patientResponses = patientList.Select(x => patientMapper.ConvertToResponse(x)).ToList();
        return patientResponses;
    }

    public Patient Delete(int id)
    {
        Patient? patient= patientRepository.GetById(id);
        patientRepository.Remove(patient);
        return patient;
    }
}