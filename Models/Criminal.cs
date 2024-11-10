using DataProjectDb.Models;

namespace DataProject.Models
{
    public class Criminal
    {
        public int CriminalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => DateTime.Now.Year - DateOfBirth.Year;
        public string NickName { get; set; }
        public string CriminalPictureUrl { get; set; }
        public string CriminalDescription { get; set; }
        public string LastKnownLocation { get; set; }
        public string Nationality { get; set; } 
        public string CriminalHistory {  get; set; }

        // Navigation property for many-to-many relationship with Offenses

        public List<OffencesStatistics> OffencesStatistics { get; set; }
        public List<VictimStatistics> VictimStatistics { get; set; }
    }
}
