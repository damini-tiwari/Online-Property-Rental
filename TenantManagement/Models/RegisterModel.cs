using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TenantManagement.Models
{
    public class RegisterModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public Guid TenantId { get; set; }


        [Required(ErrorMessage = "{0} can't be empty or null")]
        [Display(Name = "Username")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        [RegularExpression("^[A-Za-z]$", ErrorMessage = "{0} should contain only alphabets, space and dot (.)")]
        public string Username { get; set; }


        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "The password must contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }


        [Required]
        public string Tenant_name { get; set; }

        [Required]
        public string Gender { get; set; }


        [Required]
        [MinimumAge(18, ErrorMessage = "Age should be more than 18")]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0: dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dob { get; set; }
    }
}
