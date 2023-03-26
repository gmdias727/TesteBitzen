
using Microsoft.AspNetCore.Mvc;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;
using TesteBitzen.ViewModels;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace TesteBitzen.Controllers
{
    [Route("api[controller]")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<RentalModel>>> GetAllRentals()
        {
            List<RentalModel> rental = await _rentalRepository.GetAllRentals();
            return Ok(rental);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RentalModel>> GetRentalById(int id)
        {
            RentalModel rental = await _rentalRepository.GetRentalById(id);
            return Ok(rental);
        }

        [HttpPost]
        public async Task<ActionResult<RentalModel>> AddRental([FromBody] CreateRentalViewModel rental)
        {
            var providedRental = new RentalModel
            {
                StartDate = rental.StartDate,
                EndDate = rental.EndDate,
                RentCost = rental.RentCost,
                Vehicle = rental.Vehicle,
                User = rental.User,
            };

            RentalModel ProvidedRental = await _rentalRepository.AddRental(providedRental);
            return Ok(ProvidedRental);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RentalModel>> UpdateRental([FromBody] UpdateRentalViewModel rental, int id)
        {
            var providedRental = await _rentalRepository.GetRentalById(id);

            if (providedRental == null)
            {
                return NotFound("Rental not found");
            }

            providedRental.StartDate = rental.StartDate ?? providedRental.StartDate;
            providedRental.EndDate = rental.EndDate ?? providedRental.EndDate;
            providedRental.RentCost = rental.RentCost;
            providedRental.Vehicle = rental.Vehicle ?? providedRental.Vehicle;
            providedRental.User = rental.User?? providedRental.User;

            await _rentalRepository.UpdateRental(providedRental, id);
            return Ok(providedRental);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RentalModel>> DeleteRental(int id)
        {
            bool providedRental = await _rentalRepository.DeleteRental(id);
            return Ok(providedRental);
        }
    }
}
