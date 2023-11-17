using Medicos_API.Models;

namespace Medicos_API.DTOs
{
    public class DoctorInsertDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }
        public Adress? Adress { get; set; }
    }
}
