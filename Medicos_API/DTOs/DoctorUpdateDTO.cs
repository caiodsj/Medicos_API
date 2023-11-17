using Medicos_API.Models;

namespace Medicos_API.DTOs
{
    public class DoctorUpdateDTO
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialty { get; set; }

    }
}
