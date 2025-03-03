using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Property
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PropertyId { get; set; }

    [Required]
    public string Address { get; set; }

    public string Description { get; set; }

    public decimal Rent { get; set; }
}

