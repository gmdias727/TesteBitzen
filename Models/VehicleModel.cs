
namespace TesteBitzen.Models
{
    public class VehicleModel
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleAssembler { get; set; }


        public int UserId { get; set; }
        public int VehicleCategoryId { get; set; }


        public virtual UserModel User { get; set; }
        public virtual VehicleCategoryModel VehicleCategory { get; set; }
    }
}
