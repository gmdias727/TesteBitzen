using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TesteBitzen.Models;

namespace TesteBitzen.Data.Map
{
    public class RentalMap : IEntityTypeConfiguration<RentalModel>
    {
        public void Configure(EntityTypeBuilder<RentalModel> builder)
        {
            builder.HasKey(x => x.RentalId);
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.RentCost);
            builder.Property(x => x.VehicleId).IsRequired();
            builder.Property(x => x.UserId).IsRequired();

            //builder
            //    .HasOne(rental => rental.User)
            //    .WithOne(user => user.Rental)
            //    .HasForeignKey<UserModel>(user => user.UserId);

            //builder
            //    .HasOne(rental => rental.Vehicle)
            //    .WithOne(vehicle => vehicle.Rental)
            //    .HasForeignKey<VehicleModel>(vehicle => vehicle.VehicleId);
        }
    }
}
