namespace GymManagementSystem.DataAccess.Models
{
    public class MemberShip : BaseEntity
    {
        // StartDate = CreatesAt of BaseEntity
        public DateTime EndDate { get; set; }

        public int MemberId { get; set; }
        public Member Member { get; set; } = default!;

        public int PlanId { get; set; }
        public Plan Plan { get; set; } = default!;


        public string status => EndDate > DateTime.Now ? "Active" : "Expired"; 
        public bool IsActive => EndDate > DateTime.Now;

    }
}
