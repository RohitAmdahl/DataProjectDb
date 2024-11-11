using DataProjectDb.Models;
using System.ComponentModel.DataAnnotations;

namespace DataProject.Models
{
    public class OffenceVictim
    {
        public int OffencesId { get; set; }
        public Offence Offence { get; set; }
        public int VictimId { get; set; }
        public Victim Victim { get; set; }
    }
}
