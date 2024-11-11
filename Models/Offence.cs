using DataProject.Models;
using DataProjectDb.Models;
using System.ComponentModel.DataAnnotations;

public class Offence
{
    [Key]
    [Required]
    public int OffencesId { get; set; }
    [Required]
    [MaxLength(250)]
    public string OffenceName { get; set; }
    [Required]
    public int Count { get; set; } 
    [Required]
    public int Year { get; set; }

    // Many-to-one relationship with Criminal
    public int CriminalId { get; set; }
    public Criminal Criminal { get; set; }

    // Many-to-many relationship with Victims through OffenceVictim
    public List<OffenceVictim> OffenceVictims { get; set; }
}
