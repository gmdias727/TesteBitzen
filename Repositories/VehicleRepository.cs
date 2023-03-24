using Microsoft.EntityFrameworkCore;
using TesteBitzen.Data;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly VehicleRentDbContext _dbContext;

        public VehicleRepository(VehicleRentDbContext vehicleRentDbContext)
        {
            _dbContext = vehicleRentDbContext;
        }

        public async Task<List<VehicleModel>> GetAllVehicles()
        {
            return await _dbContext.Vehicles
                .Include(x => x.VehicleCategory)
                .ToListAsync();
        }

        public async Task<VehicleModel> GetVehicleById(int id)
        {
            return await _dbContext.Vehicles.FirstOrDefaultAsync(x => x.VehicleId == id);
        }

        public async Task<VehicleModel> GetVehicleByUserId(int id)
        {
            return await _dbContext.Vehicles.Include(x => x.User).FirstOrDefaultAsync(x => x.VehicleId == id);
        }

        public async Task<VehicleModel> AddVehicle(VehicleModel vehicle)
        {
            await _dbContext.Vehicles.AddAsync(vehicle);
            await _dbContext.SaveChangesAsync();

            return vehicle;
        }
        public async Task<VehicleModel> UpdateVehicle(VehicleModel vehicle, int id)
        {
            VehicleModel ProvidedVehicle = await GetVehicleById(id) ?? throw new Exception($"This provided Vehicle ID: {id} was not found");

            ProvidedVehicle.VehicleName = vehicle.VehicleName;
            ProvidedVehicle.VehicleAssembler = vehicle.VehicleAssembler;
            ProvidedVehicle.VehicleCategoryId = vehicle.VehicleCategoryId;

            _dbContext.Vehicles.Update(ProvidedVehicle);
            await _dbContext.SaveChangesAsync();

            return ProvidedVehicle;
        }

        public async Task<bool> DeleteVehicle(int id)
        {
            VehicleModel ProvidedVehicle = await GetVehicleById(id) ?? throw new Exception($"The provided Vehicle ID: {id} was not found or don't exist");

            _dbContext.Vehicles.Remove(ProvidedVehicle);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
