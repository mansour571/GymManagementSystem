namespace GymManagementSystem.DataAccess.Models
{
    public class Booking : BaseEntity
    {
        // BookingDate = CreatesAt of BaseEntity
        public bool Attended { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int SessionId { get; set; }
        public Session Session { get; set; } = default!;
        
    }
}
