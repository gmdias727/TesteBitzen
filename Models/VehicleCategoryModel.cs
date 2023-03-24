namespace TesteBitzen.Models
{
    public class VehicleCategoryModel
    {
        public int VehicleCategoryId { get; set; }
        public string? VehicleCategory { get; set; } 
        public string? VehicleFuelType { get; set; }
        public double? VehicleRentCost { get; set; }

        public int VehicleId { get; set; }
        public virtual VehicleModel Vehicle { get; set; }

    }
}
