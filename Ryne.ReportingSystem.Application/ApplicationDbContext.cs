#nullable disable
using Microsoft.EntityFrameworkCore;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application
{
    public class ApplicationDbContext : DbContext    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Defectoscope> Defectoscopes { get; set; }
        public DbSet<Repair> Repair { get; set; }
        public DbSet<Engineer> Engineer { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<TypeOfDefectoscope>  TypeOfDefectoscopes { get; set;}

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
#nullable enable
