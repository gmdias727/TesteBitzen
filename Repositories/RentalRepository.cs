using Microsoft.EntityFrameworkCore;
using TesteBitzen.Data;
using TesteBitzen.Models;
using TesteBitzen.Repositories.Interfaces;

namespace TesteBitzen.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly VehicleRentDbContext _dbContext;

        public RentalRepository(VehicleRentDbContext vehicleRentDbContext)
        {
            _dbContext = vehicleRentDbContext;
        }

        public async Task<List<RentalModel>> GetAllRentals()
        {
            return await _dbContext.Rentals
                .Include(x => x.UserId)
                .Include(x => x.VehicleId)
                .ToListAsync();
        }

        public async Task<RentalModel> GetRentalById(int id)
        {
            return await _dbContext.Rentals
                .FirstOrDefaultAsync(x => x.RentalId == id);
        }

        public async Task<RentalModel> AddRental(RentalModel rental)
        {
            await _dbContext.Rentals.AddAsync(rental);
            await _dbContext.SaveChangesAsync();

            return rental;
        }

        public async Task<RentalModel> UpdateRental(RentalModel rental, int id)
        {
            RentalModel providedRental = await GetRentalById(id) ?? throw new Exception($"This provided Rental ID: {id} was not found");

            providedRental.StartDate = DateTime.Now;
            providedRental.EndDate = DateTime.Now;
            providedRental.RentCost = rental.RentCost;
            providedRental.VehicleId = rental.VehicleId;
            providedRental.UserId = rental.UserId;

            _dbContext.Rentals.Update(providedRental);
            await _dbContext.SaveChangesAsync();

            return providedRental;
            
        }

        public async Task<bool> DeleteRental(int id)
        {
            RentalModel providedRental = await GetRentalById(id) ?? throw new Exception($"The provided Rental ID: {id} was not found or don't exist");

            _dbContext.Rentals.Remove(providedRental);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        


    }
}
