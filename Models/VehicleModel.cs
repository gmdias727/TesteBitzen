
namespace TesteBitzen.Models
{
    public class VehicleModel
    {
        public long VehicleId { get; set; }
        public string? VehicleName { get; set; }
        public string? VehicleAssembler { get; set; }


        public long UserId { get; set; }
        public long VehicleCategoryId { get; set; }


        public virtual UserModel? User { get; set; }
        public virtual VehicleCategoryModel? VehicleCategory { get; set; }
    }
}
