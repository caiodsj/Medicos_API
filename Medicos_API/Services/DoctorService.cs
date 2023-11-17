using Medicos_API.Data;
using Medicos_API.DTOs;
using Medicos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicos_API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly DataContext _context;

        public DoctorService(DataContext context)
        {
            _context = context;
        }

        public async Task<Doctor> CreateDoctor(DoctorInsertDTO request, AdressInsertDTO adressRequest)
        {
            var doctor = new Doctor
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                Specialty = request.Specialty,
                CRM = request.CRM,
                Adress = new Adress
                {
                    State = adressRequest.State,
                    City = adressRequest.City,
                    Street = adressRequest.Street,
                    ZipCode = adressRequest.ZipCode,
                    Neighborhood = adressRequest.Neighborhood,
                    Number = adressRequest.Number,
                    Complement = adressRequest.Complement
                }
            };
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task<string> DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor is null) return null;
            _context.Remove(doctor);
            await _context.SaveChangesAsync(true);
            return $"{doctor.Name} excluído com sucesso";
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsByState(string state)
        {
            return await _context.Doctors
                .Where(d => d.Adress != null && d.Adress.State == state)
                .ToListAsync();
        }


        public async Task<Doctor> GetDoctorByCRM(string CRMrequest)
        {
            return await _context.Doctors
                .Include(d => d.Adress)
                .FirstOrDefaultAsync(d => d.CRM == CRMrequest);
        }


        public async Task<Doctor> UpdateDoctor(int id, DoctorUpdateDTO request)
        {
            var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor is null) return null;
            
            doctor.Name = request.Name;
            doctor.Phone = request.Phone;
            doctor.Email = request.Email;
            doctor.Specialty = request.Specialty;

            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
