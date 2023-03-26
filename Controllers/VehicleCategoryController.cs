using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;
using TesteBitzen.ViewModels;

namespace TesteBitzen.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class VehicleCategoryController : ControllerBase
    {
        private readonly IVehicleCategoryRepository _vehicleCategoryRepository;

        public VehicleCategoryController(IVehicleCategoryRepository vehicleCategoryRepository)
        {
            _vehicleCategoryRepository = vehicleCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleCategoryModel>>> GetAllVehicleCategories()
        {
            List<VehicleCategoryModel> providedVehicleCategory = await _vehicleCategoryRepository.GetAllVehicleCategories();
            return Ok(providedVehicleCategory);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleCategoryModel>> GetVehicleCategoryById(int vehicleCategoryId)
        {
            VehicleCategoryModel providedVehicleCategory = await _vehicleCategoryRepository.GetVehicleCategoryById(vehicleCategoryId);
            return Ok(providedVehicleCategory);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleCategoryModel>> AddVehicleCategory([FromBody] CreateVehicleCategoryViewModel vehicleCategory)
        {
            var providedVehicleCategory = new VehicleCategoryModel
            {
                VehicleCategory = vehicleCategory.VehicleCategory,
                VehicleFuelType = vehicleCategory.VehicleFuelType,
                VehicleRentCost = vehicleCategory.VehicleRentCost,
                Vehicle = vehicleCategory.Vehicle,
            };

            VehicleCategoryModel VehicleCategory = await _vehicleCategoryRepository.AddVehicleCategory(providedVehicleCategory);
            return Ok(VehicleCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleCategoryModel>> UpdateVehicleCategory([FromBody] UpdateVehicleCategoryViewModel vehicleCategoryModel, int id)
        {
            var vehicleCategory = await _vehicleCategoryRepository.GetVehicleCategoryById(id);

            if (vehicleCategory == null)
            {
                return NotFound("Vehicle category not found");
            }

            vehicleCategory.VehicleCategory = vehicleCategoryModel.VehicleCategory ?? vehicleCategory.VehicleCategory;
            vehicleCategory.VehicleFuelType = vehicleCategoryModel.VehicleFuelType?? vehicleCategory.VehicleFuelType;
            vehicleCategory.VehicleRentCost = vehicleCategoryModel.VehicleRentCost ?? vehicleCategory.VehicleRentCost;
            vehicleCategory.Vehicle = vehicleCategoryModel.Vehicle ?? vehicleCategory.Vehicle;

            await _vehicleCategoryRepository.UpdateVehicleCategory(vehicleCategory, id);
            return Ok(vehicleCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleCategoryModel>> DeleteVehicleCategory(int veicleCategoryId)
        {
            bool providedVehicleCategory = await _vehicleCategoryRepository.DeleteVehicleCategory(veicleCategoryId);
            return Ok(providedVehicleCategory);
        }

    }
}
