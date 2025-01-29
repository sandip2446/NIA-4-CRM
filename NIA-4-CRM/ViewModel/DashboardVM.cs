using NIA_4_CRM.Models;

namespace NIA_4_CRM.ViewModel
{
    public class DashboardVM
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int ExpiredMembers { get; set; }
        public List<Member> RecentMembers { get; set; }
        public List<MembershipTypeCount> MembershipTypeCounts { get; set; }
    }
}
