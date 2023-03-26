using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TesteBitzen.Data.Map;
using TesteBitzen.Models;

namespace TesteBitzen.Data
{
    public class VehicleRentDbContext : DbContext
    {
        public VehicleRentDbContext(DbContextOptions<VehicleRentDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new VehicleMap());
            modelBuilder.ApplyConfiguration(new VehicleCategoryMap());
            modelBuilder.ApplyConfiguration(new RentalMap());

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>()
                .HasOne(x => x.Vehicle)
                .WithOne(x => x.User)
                .HasForeignKey<VehicleModel>(x => x.UserId);

            modelBuilder.Entity<VehicleModel>()
                .HasOne(x => x.VehicleCategory)
                .WithOne(x => x.Vehicle)
                .HasForeignKey<VehicleCategoryModel>(x => x.VehicleCategoryId);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<VehicleCategoryModel> VehicleCategories { get; set; }
        public DbSet<RentalModel> Rentals { get; set; }

    }
}
