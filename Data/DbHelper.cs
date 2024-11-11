using DataProject.Models;
using DataProjectDb.Models;
using Microsoft.EntityFrameworkCore;

namespace DataProject.Data
{
    public static class DbHelper
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            List<Criminal> criminals = new();
            List<Offence> offences = new();
            List<Victim> victims = new();

            criminals.Add(new()
            {
                CriminalId = 1,
                FirstName = "Larsen",
                LastName = "Jack",
                Gender = "Male",
                DateOfBirth = new DateTime(1985, 3, 15),
                NickName = "Johnny",
                CriminalPictureUrl = "https://images.unsplash.com/photo-1589304099692-7c72d558c2f3?q=80&w=1976&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                CriminalDescription = "Known for cybercrimes and fraud.",
                LastKnownLocation = "Oslo Norway",
                Nationality = "American",
                CriminalHistory = "Arrested twice for Sexual offences."
            });
            criminals.Add(new()
            {
                CriminalId = 2,
                FirstName = "Røger",
                LastName = "Hanna",
                Gender = "Male",
                DateOfBirth = new DateTime(1990, 7, 22),
                NickName = "The Phantom",
                CriminalPictureUrl = "https://images.unsplash.com/photo-1682965636797-e97babe032b7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                CriminalDescription = "Specializes in high-profile thefts.",
                LastKnownLocation = "Los Angeles",
                Nationality = "Canadian",
                CriminalHistory = "Involved in Drug and alcohol offences."
            });
            criminals.Add(new()
            {
                CriminalId = 3,
                FirstName = "Dhani",
                LastName = "Dhal",
                Gender = "Female",
                DateOfBirth = new DateTime(1990, 7, 22),
                NickName = "The Phantom",
                CriminalPictureUrl = "https://images.unsplash.com/photo-1603198565875-f53d90dc8004?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                CriminalDescription = "Specializes in high-profile thefts.",
                LastKnownLocation = "Mumbai, maharashtra, india",
                Nationality = "Canadian",
                CriminalHistory = "Involved in offences for profit."
            });

            offences.Add(new()
            {
                OffencesStatisticsId = 1,
                OffenceName = "Sexual offences",
                Count = "7484",
                Year = 2023,
                CriminalId = 1 // 
            });
            offences.Add(new()
            {
                OffencesStatisticsId = 2,
                OffenceName = "Drug and alcohol offences",
                Count = "29788",
                Year = 2022,
                CriminalId = 2
            });
            offences.Add(new()
            {
                OffencesStatisticsId = 3,
                OffenceName = "Violence and maltreatment",
                Count = "42994",
                Year = 2023,
                CriminalId = 1
            });
            offences.Add(new()
            {
                OffencesStatisticsId = 4,
                OffenceName = "Offences for profit",
                Count = "32843",
                Year = 2023,
                CriminalId = 3
            });

            victims.Add(new()
            {
                VictimId = 1,
                Year = 2023,
                VictimsName = "Alice Johnson",
                VictimsLocation = "Downtown LA"
            });
            victims.Add(new()
            {
                VictimId = 2,
                Year = 2022,
                VictimsName = "Robert Thompson",
                VictimsLocation = "Manhattan, NYC"
            });
            victims.Add(new()
            {
                VictimId = 3,
                Year = 2023,
                VictimsName = "Linda Park",
                VictimsLocation = "Brooklyn, NYC"
            });

            // Seed the main entities
            modelBuilder.Entity<Criminal>().HasData(criminals);
            modelBuilder.Entity<Victim>().HasData(victims);
            modelBuilder.Entity<Offence>().HasData(offences);

            // Seed the many-to-many relationship data
            // Seed many-to-many relationships
            modelBuilder.Entity<Offence>()
                .HasMany(offences => offences.Victims)
                .WithMany( victims => victims.Criminals)
                .UsingEntity(join => join.HasData(
                    new { OffencesStatisticsId = 1, VictimId = 1 },
                    new { OffencesStatisticsId = 2, VictimId = 2 },
                     new { OffencesStatisticsId = 3, VictimId = 3 }
                ));
        }
    }
}
