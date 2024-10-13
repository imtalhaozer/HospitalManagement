using HospitalManagement.Models.Dtos.Request;
using HospitalManagement.Service.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppoinmentController : ControllerBase
    {
        private readonly IAppoinmentService _appoinmentService;

        public AppoinmentController(IAppoinmentService appoinmentService)
        {
            _appoinmentService = appoinmentService;
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateAppoinmentRequest newAppoinment)
        {
            var result = _appoinmentService.Add(newAppoinment);
            if (!result.Success)
            {
                return StatusCode((int)result.Code, result);
            }
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromBody] CreateAppoinmentRequest updatedAppoinment)
        {
            var result = _appoinmentService.Update(updatedAppoinment);
            if (!result.Success)
            {
                return StatusCode((int)result.Code, result);
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _appoinmentService.GetById(id);
            if (!result.Success)
            {
                return StatusCode((int)result.Code, result);
            }
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _appoinmentService.GetAll();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var result = _appoinmentService.Delete(id);
            if (!result.Success)
            {
                return StatusCode((int)result.Code, result);
            }
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteOutDatedAppoinments()
        {
            var result = _appoinmentService.OutdatedAppointment();
            return Ok(result);
        }
    }
}
