using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;
using TesteBitzen.ViewModels;

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
        public async Task<ActionResult<VehicleModel>> AddVehicle([FromBody] CreateVehicleViewModel vehicle)
        {
            var providedVehicle = new VehicleModel
            {
                VehicleName = vehicle.VehicleName,
                VehicleAssembler = vehicle.VehicleAssembler,
                User = vehicle.User,
                VehicleCategory = vehicle.VehicleCategory,
                Rental = vehicle.Rental,
            };

            VehicleModel ProvidedVehicle = await _vehicleRepository.AddVehicle(providedVehicle);
            return Ok(ProvidedVehicle);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VehicleModel>> UpdateVehicle([FromBody] UpdateVehicleViewModel vehicle, int id)
        {
            var providedVehicle = await _vehicleRepository.GetVehicleById(id);

            if (vehicle == null)
            {
                return NotFound("Vehicle not found");
            }

            providedVehicle.VehicleName = vehicle.VehicleName?? providedVehicle.VehicleName;

            await _vehicleRepository.UpdateVehicle(providedVehicle, id);
            return Ok(providedVehicle);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VehicleModel>> DeleteVehicle(int vehicleId)
        {
            bool ProvidedVehicle = await _vehicleRepository.DeleteVehicle(vehicleId);
            return Ok(ProvidedVehicle);
        }

    }


}
