namespace GymManagementSystem.DataAccess.Models
{
    public class Booking : BaseEntity
    {
        public DateTime Date { get; set; }
        public bool Attended { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int SessionId { get; set; }
        public Session Session { get; set; } = default!;
        
    }
}
