using Medicos_API.Models;

namespace Medicos_API.DTOs
{
    public class AdressInsertDTO
    {
        public string State { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
    }
}
