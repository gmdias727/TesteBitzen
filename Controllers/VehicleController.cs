using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Controllers
{

    [Route("api[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleController(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<VehicleModel>>> GetAllVehicles()
        {
            List<VehicleModel> vehicles = await _vehicleRepository.GetAllVehicles();
            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VehicleModel>> GetVehicleById(int vehicleId)
        {
            VehicleModel vehicle = await _vehicleRepository.GetVehicleById(vehicleId);
            return Ok(vehicle);
        }

        [HttpPost]
        public async Task<ActionResult<VehicleModel>> AddVehicle([FromBody] VehicleModel vehicleModel)
        {
            VehicleModel ProvidedVehicle = await _vehicleRepository.AddVehicle(vehicleModel);
            return Ok(ProvidedVehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicle([FromBody] VehicleModel vehicleModel, int id)
        {
            vehicleModel.VehicleId = id;
            VehicleModel ProvidedVehicle = await _vehicleRepository.UpdateVehicle(vehicleModel, id);
            return Ok(ProvidedVehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicle(int vehicleId)
        {
            bool ProvidedVehicle = await _vehicleRepository.DeleteVehicle(vehicleId);
            return Ok(ProvidedVehicle);
        }

    }


}
