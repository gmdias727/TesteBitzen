using TesteBitzen.Models;

namespace TesteBitzen.ViewModels
{
    public class UpdateUserViewModel
    {
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }

        public virtual VehicleModel? Vehicle { get; set; }
        public virtual RentalModel? Rental { get; set; }
    }
}
