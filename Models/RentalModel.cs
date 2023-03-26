namespace TesteBitzen.Models
{
    public class RentalModel
    {
        public int RentalId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal RentCost { get; set; }

        public int VehicleId { get; set; }
        public VehicleModel? Vehicle { get; set; }

        public int UserId { get; set; }
        public UserModel? User { get; set; }
    }
}
