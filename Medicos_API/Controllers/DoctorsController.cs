using Medicos_API.DTOs;
using Medicos_API.Models;
using Medicos_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _service;

        public DoctorsController(IDoctorService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctors()
        {
            return Ok(await _service.GetAllDoctors());
        }

        [HttpGet("{CRM}")]
        public async Task<ActionResult<Doctor>> GetDoctorByCRM(string CRM)
        {
            var doctor = await _service.GetDoctorByCRM(CRM);

            if (doctor == null)
            {
                return NotFound();
            }

            return Ok(doctor);
        }

        [HttpGet("state/{state}")]
        public async Task<ActionResult<IEnumerable<Doctor>>> GetAllDoctorsByState(string state)
        {
            return Ok(await _service.GetAllDoctorsByState(state));
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor(DoctorInsertDTO request)
        {
            var doctor = await _service.CreateDoctor(request);
            if (doctor is null) return BadRequest();
            return Ok(doctor);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int id, DoctorUpdateDTO request)
        {
            var updatedDoctor = await _service.UpdateDoctor(id, request);

            if (updatedDoctor == null)
            {
                return NotFound();
            }

            return Ok(updatedDoctor);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await _service.DeleteDoctor(id);
            return Ok();
        }

    }
}
