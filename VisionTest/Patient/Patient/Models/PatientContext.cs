using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Patient.Models
{
    public class PatientContext : DbContext
    {
        public PatientContext(DbContextOptions<PatientContext> options)
            : base(options)
        {
            var optCopy = options;
        }

        public DbSet<Patient> Patient { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Phone> Phone { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<AuditLog> AuditLog { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var optCopy = optionsBuilder;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var buildCopy = modelBuilder;
        }
    }
}
