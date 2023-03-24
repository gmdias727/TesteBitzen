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

            modelBuilder.Entity<UserModel>()
                .HasOne(v => v.Vehicle)
                .WithOne(u => u.User)
                .HasForeignKey<VehicleModel>(v => v.UserId);

            modelBuilder.Entity<VehicleCategoryModel>()
                .HasOne(v => v.Vehicle)
                .WithOne(u => u.VehicleCategory)
                .HasForeignKey<VehicleModel>(v => v.VehicleCategoryId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<VehicleModel> Vehicles { get; set; }
        public DbSet<VehicleCategoryModel> VehicleCategories { get; set; }

    }
}
