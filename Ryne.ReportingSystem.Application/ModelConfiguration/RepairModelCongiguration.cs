using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application.ModelConfiguration
{
    public class RepairModelCongiguration : IEntityTypeConfiguration<Repair>
    {
        public void Configure(EntityTypeBuilder<Repair> builder)
        {
            builder.ToTable("Repairs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TypeOfRepair).HasConversion<string>();
        }
    }
}
