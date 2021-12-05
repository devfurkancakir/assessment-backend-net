using Microsoft.EntityFrameworkCore;

namespace SeturReport.Models
{
    public class ReportDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("User ID =postgres;Password=Furkanca1.;Server=localhost;Port=5432;Database=report; Integrated Security = true; Pooling = true; ");

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Report> Reports { get; set; }
    }
}