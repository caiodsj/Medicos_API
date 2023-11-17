namespace Medicos_API.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Specialty { get; set; }
        public string CRM { get; set; }
        public Adress Adress { get; set; }
    }
}
