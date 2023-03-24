
namespace TesteBitzen.Models
{

    public class UserModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }
        public int? VehicleId { get; set; }
        public virtual VehicleModel Vehicle { get; set; }
    }
}
