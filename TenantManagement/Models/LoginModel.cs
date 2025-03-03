using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TenantManagement.Models
{
    public class LoginModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]


        [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
        [Required(ErrorMessage = "{0} can't be blank")]
        public string Email { get; set; }


        [Required(ErrorMessage = "{0} can't be blank")]
        [Display(Name = "Password")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "{0} should be between {2} and {1} characters long")]
        public string Password { get; set; }
    }
}
