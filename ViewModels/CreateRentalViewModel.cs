using TesteBitzen.Models;

namespace TesteBitzen.ViewModels
{
    public class CreateRentalViewModel
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentCost { get; set; }
        public VehicleModel? Vehicle { get; set; }
        public UserModel? User { get; set; }
    }
}
