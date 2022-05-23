using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.ModelConfiguration
{
    public class DefectoscopeModelConfiguration : IEntityTypeConfiguration<Defectoscope>
    {
        public void Configure(EntityTypeBuilder<Defectoscope> builder)
        {
            builder.ToTable("Defectoscopes");
            builder.HasKey(x => x.Id);
            
        }
    }
}
