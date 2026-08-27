namespace GymManagementSystem.DataAccess.Models.ValueObjects
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; } = default!;
        public int BuildingNumber { get; set; }
    }
}
