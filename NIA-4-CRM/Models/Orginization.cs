using System.ComponentModel.DataAnnotations;

namespace NIA_4_CRM.Models
{
    public class Organization
    {
        public int Id { get; set; }

        [Display(Name = "Organization Name")]
        [Required(ErrorMessage = "You cannot leave the Organization name blank.")]
        [MaxLength(50, ErrorMessage = "Organization name cannot be more than 50 characters long.")]
        public string OrgName { get; set; } = "";

        [Required(ErrorMessage = "Website address is required.")]
        [RegularExpression(@"^(http|https)://[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}(/.*)?$", ErrorMessage = "Please follow the correct website format, e.g., http://example.com")]
        [StringLength(255)]
        [DataType(DataType.Url)]
        public string Website { get; set; } = "";

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email cannot be more than 100 characters.")]
        public string Email { get; set; } = "";

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Please enter a valid 10-digit phone number.")]
        [StringLength(10, ErrorMessage = "Phone number cannot be more than 10 digits.")]
        public string PhoneNumber { get; set; } = "";

        // Foreign key for IndustryType
        [Display(Name = "Industry Type")]
        public int IndustryTypeId { get; set; }
        public IndustryType IndustryType { get; set; }

        // New fields
        [Display(Name = "Street Address")]
        [Required(ErrorMessage = "Street address is required.")]
        [StringLength(100, ErrorMessage = "Street address cannot be more than 100 characters.")]
        public string StreetAddress { get; set; } = "";

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required.")]
        [StringLength(50, ErrorMessage = "City cannot be more than 50 characters.")]
        public string City { get; set; } = "";

        [Display(Name = "State/Province")]
        [Required(ErrorMessage = "State/Province is required.")]
        [StringLength(50, ErrorMessage = "State/Province cannot be more than 50 characters.")]
        public string StateProvince { get; set; } = "";
       
        
        [StringLength(10, ErrorMessage = "P.ostal code cannot be more than 10 characters.")]
        [Display(Name = "Postal Code")]
        [Required(ErrorMessage = "Postal code is required.")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z][ -]?\d[A-Za-z]\d$", ErrorMessage = "Invalid postal code.")]
        public string PostalCode { get; set; } = "";

       // [Display(Name = "Contact Person")]
       // [Required(ErrorMessage = "Contact person is required.")]
        //[StringLength(50, ErrorMessage = "Contact person name cannot be more than 50 characters.")]
        //public string ContactPerson { get; set; } = "";

        [Display(Name = "DOI")]
        [Required(ErrorMessage = "DOI (Date Of Inogoration  is required.")]
        [DataType(DataType.Date)]
        public DateTime DOI { get; set; }

        // M:M relationship with Contacts [ Foreign key for Contacts]
        public ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
        public ICollection<Member> Members { get; set; } = new HashSet<Member>();

    }
}
