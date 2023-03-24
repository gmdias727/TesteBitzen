using Microsoft.EntityFrameworkCore;
using TesteBitzen.Data;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Repositories
{
    public class VehicleCategoryRepository : IVehicleCategoryRepository
    {
        private readonly VehicleRentDbContext _dbContext;

        public VehicleCategoryRepository(VehicleRentDbContext vehicleRentDbContext)
        {
            _dbContext = vehicleRentDbContext;
        }

        public async Task<List<VehicleCategoryModel>> GetAllVehicleCategories()
        {
            return await _dbContext.VehicleCategories.ToListAsync();
        }

        public async Task<VehicleCategoryModel> GetVehicleCategoryById(int vehicleCategoryId)
        {
            return await _dbContext.VehicleCategories.FirstOrDefaultAsync(x => x.VehicleCategoryId == vehicleCategoryId);
        }

        public async Task<VehicleCategoryModel> AddVehicleCategory(VehicleCategoryModel vehicleCategory)
        {
            await _dbContext.VehicleCategories.AddAsync(vehicleCategory);
            await _dbContext.SaveChangesAsync();

            return vehicleCategory;
        }

        public async Task<VehicleCategoryModel> UpdateVehicleCategory(VehicleCategoryModel vehicleCategory, int vehicleCategoryId)
        {
            VehicleCategoryModel ProvidedVehicleCategory = await GetVehicleCategoryById(vehicleCategoryId);

            if (ProvidedVehicleCategory == null)
            {
                throw new Exception($"This provided vehicle category ID: {vehicleCategoryId} was not found or doesn't exist");
            }

            _dbContext.VehicleCategories.Update(ProvidedVehicleCategory);
            await _dbContext.SaveChangesAsync();

            return ProvidedVehicleCategory;
        }

        public async Task<bool> DeleteVehicleCategory(int vehicleCategoryId)
        {
            VehicleCategoryModel ProvidedVehicleCategory = await GetVehicleCategoryById(vehicleCategoryId);

            if (ProvidedVehicleCategory == null)
            {
                throw new Exception($"This provided vehicle category ID: {ProvidedVehicleCategory} was not found or doesn't exist");
            }

            _dbContext.VehicleCategories.Remove(ProvidedVehicleCategory);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
