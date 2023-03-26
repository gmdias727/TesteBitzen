using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBitzen.Models;

namespace TesteBitzen.Data.Map
{
    public class VehicleMap : IEntityTypeConfiguration<VehicleModel>
    {
        public void Configure(EntityTypeBuilder<VehicleModel> builder)
        {
            builder.HasKey(x => x.VehicleId);
            builder.Property(x => x.VehicleName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.VehicleAssembler).IsRequired().HasMaxLength(255);

            builder.Property(x => x.UserId).IsRequired();

        }
    }
}
