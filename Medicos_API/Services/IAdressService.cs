using Medicos_API.DTOs;
using Medicos_API.Models;

namespace Medicos_API.Services
{
    public interface IAdressService
    {
        Task<Adress> GetAdressByDoctorId(int id);
        Task<Adress> UpdateAdress(int id, AdressInsertDTO request);

    }
}
