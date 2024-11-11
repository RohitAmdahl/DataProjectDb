using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataProject.Migrations
{
    /// <inheritdoc />
    public partial class seeding_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Criminals",
                columns: new[] { "CriminalId", "CriminalDescription", "CriminalHistory", "CriminalPictureUrl", "DateOfBirth", "FirstName", "Gender", "LastKnownLocation", "LastName", "Nationality", "NickName" },
                values: new object[,]
                {
                    { 1, "Known for cybercrimes and fraud.", "Arrested twice for Sexual offences.", "https://images.unsplash.com/photo-1589304099692-7c72d558c2f3?q=80&w=1976&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", new DateTime(1985, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Larsen", "Male", "Oslo, Norway", "Jack", "American", "Johnny" },
                    { 2, "Specializes in high-profile thefts.", "Involved in Drug and alcohol offences.", "https://images.unsplash.com/photo-1682965636797-e97babe032b7?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Røger", "Male", "Los Angeles", "Hanna", "Canadian", "The Phantom" },
                    { 3, "Specializes in high-profile thefts.", "Involved in offences for profit.", "https://images.unsplash.com/photo-1603198565875-f53d90dc8004?q=80&w=1974&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D", new DateTime(1990, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dhani", "Female", "Mumbai, maharashtra, india", "Dhal", "Canadian", "The Phantom" }
                });

            migrationBuilder.InsertData(
                table: "Victims",
                columns: new[] { "VictimId", "VictimsLocation", "VictimsName", "Year" },
                values: new object[,]
                {
                    { 1, "Brooklyn, NYC", "Linda Park", 2023 },
                    { 2, "Manhattan, NYC", "Robert Thompson", 2022 },
                    { 3, "Brooklyn, NYC", "Linda Park", 2023 }
                });

            migrationBuilder.InsertData(
                table: "Offences",
                columns: new[] { "OffencesId", "Count", "CriminalId", "OffenceName", "Year" },
                values: new object[,]
                {
                    { 1, 7484, 1, "Sexual offences", 2023 },
                    { 2, 29788, 2, "Drug and alcohol offences", 2022 },
                    { 3, 42994, 1, "Violence and maltreatment", 2023 }
                });

            migrationBuilder.InsertData(
                table: "OffenceVictims",
                columns: new[] { "OffencesId", "VictimId", "CriminalId" },
                values: new object[,]
                {
                    { 1, 2, null },
                    { 2, 1, null },
                    { 2, 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Criminals",
                keyColumn: "CriminalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OffenceVictims",
                keyColumns: new[] { "OffencesId", "VictimId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "OffenceVictims",
                keyColumns: new[] { "OffencesId", "VictimId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "OffenceVictims",
                keyColumns: new[] { "OffencesId", "VictimId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Offences",
                keyColumn: "OffencesId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Offences",
                keyColumn: "OffencesId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Offences",
                keyColumn: "OffencesId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Victims",
                keyColumn: "VictimId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Victims",
                keyColumn: "VictimId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Victims",
                keyColumn: "VictimId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Criminals",
                keyColumn: "CriminalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Criminals",
                keyColumn: "CriminalId",
                keyValue: 2);
        }
    }
}
