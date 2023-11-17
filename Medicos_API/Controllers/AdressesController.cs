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

        [HttpGet("{CRM}")]
        public async Task<ActionResult<Adress>> GetAdressByCRM(string CRM)
        {
            var adress = await _service.GetAdressByCRM(CRM);

            if (adress == null)
            {
                return NotFound();
            }

            return adress;
        }

        [HttpPut("{CRM}")]
        public async Task<ActionResult<Adress>> UpdateAdress(string CRM, AdressInsertDTO request)
        {
            var updatedAdress = await _service.UpdateAdress(CRM, request);

            if (updatedAdress == null)
            {
                return NotFound();
            }

            return updatedAdress;
        }
    }
}
