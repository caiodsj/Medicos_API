using Medicos_API.Data;
using Medicos_API.DTOs;
using Medicos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicos_API.Services
{
    public class AdressService : IAdressService
    {
        private readonly DataContext _context;

        public AdressService(DataContext context)
        {
            _context = context;
        }

        public async Task<Adress> GetAdressByCRM(string CRMrequest)
        {
            var doctor = await _context.Doctors
            .Include(d => d.Adress)
            .FirstOrDefaultAsync(d => d.CRM == CRMrequest);

            return doctor?.Adress;
        }

        public async Task<Adress> UpdateAdress(string CRMdoctor, AdressInsertDTO request)
        {
            var doctor = await _context.Doctors
                .Include(d => d.Adress)
                .FirstOrDefaultAsync(d => d.CRM == CRMdoctor);

            if (doctor is null) return null;

            doctor.Adress.State = request.State;
            doctor.Adress.City = request.City;
            doctor.Adress.Street = request.Street;
            doctor.Adress.ZipCode = request.ZipCode;
            doctor.Adress.Neighborhood = request.Neighborhood;
            doctor.Adress.Number = request.Number;
            doctor.Adress.Complement = request.Complement;

            await _context.SaveChangesAsync();

            return doctor.Adress;
        }


    }
}
