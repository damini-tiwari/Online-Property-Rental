using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

public class RentalApplication
{

    public RentalApplication()
    {
        ApplicationId = Guid.NewGuid(); // Automatically generate GUID
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid ApplicationId { get; set; }

    [Required]
    public int TenantId { get; set; }

    [Required]
    public int No_of_renters { get; set; }

    [Required]
    public int Time_span { get; set; }

    [Phone(ErrorMessage = "{0} should contain 10 digits")]
    [Required]
    public int Ph_no {  get; set; }

    [Required]
    public string Email { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public DateTime Check_in_tentative { get; set; }

    public string Status { get; set; }

    public Tenant Tenant { get; set; } = null!;
}
