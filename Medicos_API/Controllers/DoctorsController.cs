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
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _service.GetAllDoctors();
        }

        [HttpGet("{CRM}")]
        public async Task<ActionResult<Doctor>> GetDoctorByCRM(string CRM)
        {
            var doctor = await _service.GetDoctorByCRM(CRM);

            if (doctor == null)
            {
                return NotFound();
            }

            return doctor;
        }

        [HttpGet("state/{state}")]
        public async Task<IEnumerable<Doctor>> GetAllDoctorsByState(string state)
        {
            return await _service.GetAllDoctorsByState(state);
        }

        [HttpPost]
        public async Task<ActionResult<Doctor>> CreateDoctor(DoctorInsertDTO request, AdressInsertDTO adressRequest)
        {
            var doctor = await _service.CreateDoctor(request, adressRequest);
            return CreatedAtAction(nameof(GetDoctorByCRM), new { CRM = doctor.CRM }, doctor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Doctor>> UpdateDoctor(int id, DoctorUpdateDTO request)
        {
            var updatedDoctor = await _service.UpdateDoctor(id, request);

            if (updatedDoctor == null)
            {
                return NotFound();
            }

            return updatedDoctor;
        }

        [HttpDelete("{CRM}")]
        public async Task<ActionResult<string>> DeleteDoctor(string CRM)
        {
            var result = await _service.DeleteDoctor(CRM);

            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
    }
}
