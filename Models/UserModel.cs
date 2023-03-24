
namespace TesteBitzen.Models
{

    public class UserModel
    {
        public long UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhone { get; set; }

        public VehicleModel? Vehicle { get; set; }
    }
}
