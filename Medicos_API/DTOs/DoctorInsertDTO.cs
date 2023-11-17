using Medicos_API.Models;

namespace Medicos_API.DTOs
{
    public class DoctorInsertDTO
    {
        public required string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public required string CRM { get; set; }
        public bool AcceptSample { get; set; }
        public AdressInsertDTO Adress { get; set; }
    }
}
