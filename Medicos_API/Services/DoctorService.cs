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

        public async Task<Doctor> CreateDoctor(DoctorInsertDTO request)
        {
            var doctor = new Doctor
            {
                Name = request.Name,
                Phone = request.Phone,
                Email = request.Email,
                CPF = request.CPF,
                Specialty = request.Specialty,
                CRM = request.CRM,
                AcceptSample = false,
                Adress = new Adress()
            };
            await _context.Doctors.AddAsync(doctor);
            await _context.SaveChangesAsync();
            return doctor;
        }

        public async Task DeleteDoctor(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctors.Remove(doctor);
                await _context.SaveChangesAsync();
            }
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
            doctor.CRM = request.CRM;
            doctor.CPF = request.CPF;
            doctor.Specialty = request.Specialty;
            doctor.AcceptSample = request.AcceptSample;

            await _context.SaveChangesAsync();
            return doctor;
        }
    }
}
