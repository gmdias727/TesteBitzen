using TesteBitzen.Models;

namespace TesteBitzen.Repositories.Interfaces
{
    public interface IVehicleRepository
    {
        Task<List<VehicleModel>> GetAllVehicles();
        
        Task<VehicleModel> GetVehicleById(int id);

        Task<VehicleModel> GetVehicleByUserId(int id);

        Task<VehicleModel> AddVehicle(VehicleModel vehicle);

        Task<VehicleModel> UpdateVehicle(VehicleModel vehicle, int id);

        Task<bool> DeleteVehicle(int id);

    }
}
