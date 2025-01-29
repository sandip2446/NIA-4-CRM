using System.ComponentModel.DataAnnotations;

namespace NIA_4_CRM.Models
{
    public class MembershipType
    {
        public int MembershipTypeId { get; set; }

        [Display(Name ="Membership Type")]
        [Required(ErrorMessage = "Membership type name is required.")]
        [StringLength(100, ErrorMessage = "Membership type name cannot be more than 100 characters.")]
        public string MembershipName { get; set; } = "";

        // ICollection to hold multiple contacts related to this member
        public ICollection<Member> Members { get; set; } = new List<Member>();




    }
}
