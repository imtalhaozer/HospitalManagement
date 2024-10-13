using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Service.Abstracts;
using HospitalManagement.Service.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateDoctorRequest newDoctor)
        {
            var doctor = _doctorService.Add(newDoctor);
            return Ok(doctor);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CreateDoctorRequest updatedDoctor)
        {
            var doctor = _doctorService.Update(updatedDoctor);
            return Ok(doctor);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var doctor = _doctorService.GetById(id);
            return Ok(doctor);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var doctors = _doctorService.GetAll();
            return Ok(doctors);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doctor = _doctorService.Delete(id);
            return Ok(doctor);
        }
    }
}
