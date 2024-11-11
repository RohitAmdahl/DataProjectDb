using DataProject.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataProjectDb.Models
{
    public class Victim
    {
        [Key]
        [Required]
        public int VictimId { get; set; }
        [Required]
        public int Year { get; set; }
        [MaxLength(250)]
        [MaybeNull]
        public string VictimsName { get; set; } 
        [MaxLength(250)]
        public string VictimsLocation { get; set; }

        // Many-to-Many relationship with Criminals
        public List<Criminal> Criminals { get; set; }
    }
}
