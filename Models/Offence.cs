using DataProject.Models;
using System.ComponentModel.DataAnnotations;

namespace DataProjectDb.Models
{
    public class Offence
    {
        [Key]
        [Required]
        public int OffencesStatisticsId { get; set; }
        [Required]
        [MaxLength(250)]
        public string OffenceName { get; set; }
        [Required]
        [MaxLength(250)]
        public string Count { get; set; }
        [Required]
        [MaxLength(250)]
        public int Year { get; set; }

        //  Navigation property for the relationship
        // Foreign Key for Criminal
        public int CriminalId { get; set; }
        public Criminal Criminal { get; set; }

        // Many-to-Many relationship with Victims
        public List<Victim> Victims { get; set; }

    }
}
