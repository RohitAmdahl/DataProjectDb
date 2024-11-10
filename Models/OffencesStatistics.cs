using DataProject.Models;
using System.ComponentModel.DataAnnotations;

namespace DataProjectDb.Models
{
    public class OffencesStatistics
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

        //  // Navigation property for the relationship
        public int CriminalId { get; set; }
        public Criminal Criminals { get; set; }
        public List<Criminal> Criminal { get; set; }
        //public int VictimStatisticsId { get; set; }
        //public VictimStatistics VictimStatistics { get; set; }


    }
}
