using DataProjectDb.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace DataProject.Models
{
    public class Criminal
    {
        [Key]
        [Required]
        public int CriminalId { get; set; }
        [Required]
        [MaxLength(250)]
        [MaybeNull]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(250)]
        [MaybeNull]
        public string LastName { get; set; }
        [Required]
        [MaxLength(250)]
        [MaybeNull]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        [Required]
        [MaxLength(250)]
        [MaybeNull]
        public string NickName { get; set; }
        [Required]
        [MaxLength(250)]
        public string CriminalPictureUrl { get; set; }
        [Required]
        [MaxLength(250)]
        public string CriminalDescription { get; set; }
        public string LastKnownLocation { get; set; }
        public string Nationality { get; set; } 
        public string CriminalHistory {  get; set; }

        // Navigation property 
        // One-to-Many relationship with Offenses
        public List<Offence> Offenses { get; set; }

        // Many-to-Many relationship with Victims
        public List<Victim> Victims { get; set; }


    }
}
