using TesteBitzen.Models;

namespace TesteBitzen.Repositories.Interfaces
{
    public interface IVehicleCategoryRepository
    {
        Task<List<VehicleCategoryModel>> GetAllVehicleCategories();

        Task<VehicleCategoryModel> GetVehicleCategoryById(int vehicleCategoryId);

        Task<VehicleCategoryModel> AddVehicleCategory(VehicleCategoryModel vehicleCategoryName);

        Task<VehicleCategoryModel> UpdateVehicleCategory(VehicleCategoryModel vehicleCategoryName, int vehicleCategoryId);

        Task<bool> DeleteVehicleCategory(int vehicleCategoryId);
    }
}