using TesteBitzen.Models;

namespace TesteBitzen.ViewModels
{
    public class UpdateVehicleCategoryViewModel
    {
        public string? VehicleCategory { get; set; }
        public string? VehicleFuelType { get; set; }
        public double? VehicleRentCost { get; set; }
        public virtual VehicleModel? Vehicle { get; set; }
    }
}
