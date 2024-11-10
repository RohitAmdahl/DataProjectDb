using DataProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataProjectDb.Models
{
    public class VictimStatistics
    {
        [Key]
        [Required]
        public int VictimStatisticsId { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        [MaxLength(250)]
        [MaybeNull]
        public string VictimsName { get; set; }
        [Required]
        [MaxLength(250)]
        public string VictimsLocation { get; set; }
        public List<OffencesStatistics>? OffencesStatisticses { get; set; }

        //  // Navigation property for the relationship
        public int CriminalId { get; set; }
        public Criminal Criminal { get; set; }

        // Many-to-Many with Criminal
        public List<Criminal> Criminals { get; set; }

    }
}
