using System.ComponentModel.DataAnnotations;

namespace causal.api.Data.TransferObjects
{
    public class DTOUser
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Not Allowed")]
        public string IdentityNumber { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Not Allowed")]
        public string PassportNumber { get; set; }

    }
}