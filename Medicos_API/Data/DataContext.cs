using Medicos_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicos_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Adress> Adresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Adress)
                .WithOne()
                .HasForeignKey<Adress>(a => a.Id)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
