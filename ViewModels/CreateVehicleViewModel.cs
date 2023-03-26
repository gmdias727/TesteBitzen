using TesteBitzen.Models;

namespace TesteBitzen.ViewModels
{
    public class CreateVehicleViewModel
    {
        public string? VehicleName { get; set; }
        public string? VehicleAssembler { get; set; }
        public virtual UserModel User { get; set; }
        public virtual VehicleCategoryModel VehicleCategory { get; set; }
        public virtual RentalModel Rental { get; set; }
    }
}
