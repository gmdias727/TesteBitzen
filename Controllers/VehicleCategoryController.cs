using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

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
        public async Task<ActionResult<VehicleCategoryModel>> AddVehicleCategory([FromBody] VehicleCategoryModel vehicleCategoryModel)
        {
            VehicleCategoryModel providedVehicleCategory = await _vehicleCategoryRepository.AddVehicleCategory(vehicleCategoryModel);
            return Ok(providedVehicleCategory);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleCategoryModel>> UpdateVehicleCategory([FromBody] VehicleCategoryModel vehicleCategoryModel, int id)
        {
            vehicleCategoryModel.VehicleCategoryId = id;
            VehicleCategoryModel providedVehicleCategory = await _vehicleCategoryRepository.UpdateVehicleCategory(vehicleCategoryModel, id);
            return Ok(providedVehicleCategory);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleCategoryModel>> DeleteVehicleCategory(int veicleCategoryId)
        {
            bool providedVehicleCategory = await _vehicleCategoryRepository.DeleteVehicleCategory(veicleCategoryId);
            return Ok(providedVehicleCategory);
        }

    }
}
