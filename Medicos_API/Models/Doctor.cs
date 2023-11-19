namespace Medicos_API.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? CPF { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }
        public bool AcceptSample { get; set; }
        public Adress Adress { get; set; }
    }
}
