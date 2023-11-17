using Medicos_API.DTOs;
using Medicos_API.Models;

namespace Medicos_API.Services
{
    public interface IAdressService
    {
        Task<Adress> GetAdressByCRM(string CRMrequest);
        Task<Adress> UpdateAdress(string CRMdoctor, AdressInsertDTO request);

    }
}
