using Medicos_API.Models;

namespace Medicos_API.DTOs
{
    public class DoctorInsertDTO
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }
        public bool AcceptSample { get; set; }
        public AdressInsertDTO Adress { get; set; }
    }
}
