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

        public async Task<Adress> GetAdressByDoctorId(int id)
        {
            var doctor = await _context.Doctors
            .Include(d => d.Adress)
            .FirstOrDefaultAsync(d => d.Id == id);

            return doctor?.Adress;
        }

        public async Task<Adress> UpdateAdress(int id, AdressInsertDTO request)
        {
            var adress = await _context.Adresses
                .FirstOrDefaultAsync(a => a.Id == id);

            if (adress is null) return null;

            adress.State = request.State;
            adress.City = request.City;
            adress.Street = request.Street;
            adress.ZipCode = request.ZipCode;
            adress.Neighborhood = request.Neighborhood;
            adress.Number = request.Number;
            adress.Complement = request.Complement;

            await _context.SaveChangesAsync();

            return adress;
        }


    }
}
