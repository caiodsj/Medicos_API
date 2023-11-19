using Medicos_API.DTOs;
using Medicos_API.Models;
using Medicos_API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicos_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly IAdressService _service;

        public AdressesController(IAdressService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Adress>> GetAdressByDoctorId(int id)
        {
            var adress = await _service.GetAdressByDoctorId(id);

            if (adress == null)
            {
                return NotFound();
            }

            return Ok(adress);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Adress>> UpdateAdress(int id, [FromBody]AdressInsertDTO request)
        {
            var updatedAdress = await _service.UpdateAdress(id, request);

            if (updatedAdress == null)
            {
                return NotFound();
            }

            return Ok(updatedAdress);
        }
    }
}
