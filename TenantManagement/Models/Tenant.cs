using TenantManagement.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using ModelValidationsExample.CustomValidators;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

public class Tenant : IdentityUser
{
    public Tenant()
    {
        TenantId = Guid.NewGuid(); // Automatically generate GUID
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

    public Guid TenantId { get; set; }


    //[Required(ErrorMessage = "{0} can't be empty or null")]
    //[Display(Name = "Username")]
    //[StringLength(40, MinimumLength = 3, ErrorMessage = "{0} should be between {2} and {1} characters long")]
    //[RegularExpression("^[A-Za-z0-9]$", ErrorMessage = "{0} should contain only alphabets,numbers")]
    public string Username { get; set; }


    [EmailAddress(ErrorMessage = "{0} should be a proper email address")]
    [Required(ErrorMessage = "{0} can't be blank")]
    public string Email { get; set; }


    [Required]
    public string Tenant_name { get; set; }

    [Required]
    public string Gender { get; set; }


    [Required]
    [MinimumAge(18, ErrorMessage = "Age should be more than 18")]
    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0: dd/mm/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime dob { get; set; }

    public List<RentalApplication> RentalApplications { get; } = new List<RentalApplication>();
}



