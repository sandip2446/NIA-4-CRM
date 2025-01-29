using System.ComponentModel.DataAnnotations;

namespace NIA_4_CRM.Models
{
    public class IndustryType
    {
        public int IndustryTypeId { get; set; }

        [Display(Name = "Industry Type")]
        [Required(ErrorMessage = "Industry type is required.")]
        [StringLength(100, ErrorMessage = "Industry type cannot be more than 100 characters.")]
        public string Name { get; set; } = "";
    }
}
