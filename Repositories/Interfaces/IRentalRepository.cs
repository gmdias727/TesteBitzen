using TesteBitzen.Models;

namespace TesteBitzen.Repositories.Interfaces
{
    public interface IRentalRepository
    {
        Task<List<RentalModel>> GetAllRentals();

        Task<RentalModel> GetRentalById(int id);

        Task<RentalModel> AddRental(RentalModel rental);

        Task<RentalModel> UpdateRental(RentalModel rental, int id);

        Task<bool> DeleteRental(int id);

    }
}
