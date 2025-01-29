using System.ComponentModel.DataAnnotations;

namespace NIA_4_CRM.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "You must select Organization .")]
        public int OrganizationId { get; set; }

        [Display(Name = "Organization Name")]
        public Organization Organization { get; set; } 
             
        [Display(Name = "Membership Start Date")]
        [Required(ErrorMessage = "You must select Membership Start Date.")]
        [DataType(DataType.Date)]
        public DateTime? MembershipStartDate { get; set; }

        [Required(ErrorMessage = "You must select Membership Renewal Date.")]
        [Display(Name = "Membership Renewal Date")]
        [DataType(DataType.Date)]
        public DateTime? MembershipRenewDate { get; set; }

        // Foreign key for MembershipType
        [Required(ErrorMessage = "You must select the Membership Type.")]
        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Status")]
        public Status Status { get; set; }


        [Required(ErrorMessage = "You must select the contact person.")]
        [Display(Name = "Contact Person")]
        public int ContactID { get; set; }

        [Display(Name = "Contact Person")]
        public Contact? Contact { get; set; }



        // Many-to-many relationship with Contacts (Representing contact persons for the Member)
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();

       


    }
}
