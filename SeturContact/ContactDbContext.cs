using Microsoft.EntityFrameworkCore;

namespace SeturContact.Models
{
    public class ContactDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Furkanca1.;Server=localhost;Port=5432;Database=contact; Integrated Security = true; Pooling = true; ");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<ContactInformation> ContactInformations { get; set; }
    }
}