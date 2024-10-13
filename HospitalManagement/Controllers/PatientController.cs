using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpPost]
        public IActionResult Add([FromBody] CreatePatientRequest newPatient)
        {
            var patient = _patientService.Add(newPatient);
            return Ok(patient);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CreatePatientRequest updatedPatient)
        {
            var patient = _patientService.Update(updatedPatient);
            return Ok(patient);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var patient = _patientService.GetById(id);
            return Ok(patient);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var patients = _patientService.GetAll();
            return Ok(patients);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var patient = _patientService.Delete(id);
            return Ok(patient);
        }
    }
}
