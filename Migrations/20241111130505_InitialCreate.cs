using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataProject.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criminals",
                columns: table => new
                {
                    CriminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CriminalPictureUrl = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CriminalDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastKnownLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nationality = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CriminalHistory = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criminals", x => x.CriminalId);
                });

            migrationBuilder.CreateTable(
                name: "Victims",
                columns: table => new
                {
                    VictimId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    VictimsName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    VictimsLocation = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Victims", x => x.VictimId);
                });

            migrationBuilder.CreateTable(
                name: "Offences",
                columns: table => new
                {
                    OffencesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OffenceName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CriminalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Offences", x => x.OffencesId);
                    table.ForeignKey(
                        name: "FK_Offences_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OffenceVictims",
                columns: table => new
                {
                    OffencesId = table.Column<int>(type: "int", nullable: false),
                    VictimId = table.Column<int>(type: "int", nullable: false),
                    CriminalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OffenceVictims", x => new { x.OffencesId, x.VictimId });
                    table.ForeignKey(
                        name: "FK_OffenceVictims_Criminals_CriminalId",
                        column: x => x.CriminalId,
                        principalTable: "Criminals",
                        principalColumn: "CriminalId");
                    table.ForeignKey(
                        name: "FK_OffenceVictims_Offences_OffencesId",
                        column: x => x.OffencesId,
                        principalTable: "Offences",
                        principalColumn: "OffencesId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OffenceVictims_Victims_VictimId",
                        column: x => x.VictimId,
                        principalTable: "Victims",
                        principalColumn: "VictimId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Offences_CriminalId",
                table: "Offences",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_OffenceVictims_CriminalId",
                table: "OffenceVictims",
                column: "CriminalId");

            migrationBuilder.CreateIndex(
                name: "IX_OffenceVictims_VictimId",
                table: "OffenceVictims",
                column: "VictimId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OffenceVictims");

            migrationBuilder.DropTable(
                name: "Offences");

            migrationBuilder.DropTable(
                name: "Victims");

            migrationBuilder.DropTable(
                name: "Criminals");
        }
    }
}
