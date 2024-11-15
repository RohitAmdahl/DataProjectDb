﻿// <auto-generated />
using System;
using DataProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataProject.Migrations
{
    [DbContext(typeof(DataProjectDbContext))]
    [Migration("20241111130505_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataProject.Models.Criminal", b =>
                {
                    b.Property<int>("CriminalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CriminalId"));

                    b.Property<string>("CriminalDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CriminalHistory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CriminalPictureUrl")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("LastKnownLocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("CriminalId");

                    b.ToTable("Criminals");
                });

            modelBuilder.Entity("DataProject.Models.OffenceVictim", b =>
                {
                    b.Property<int>("OffencesId")
                        .HasColumnType("int");

                    b.Property<int>("VictimId")
                        .HasColumnType("int");

                    b.Property<int?>("CriminalId")
                        .HasColumnType("int");

                    b.HasKey("OffencesId", "VictimId");

                    b.HasIndex("CriminalId");

                    b.HasIndex("VictimId");

                    b.ToTable("OffenceVictims");
                });

            modelBuilder.Entity("DataProjectDb.Models.Victim", b =>
                {
                    b.Property<int>("VictimId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VictimId"));

                    b.Property<string>("VictimsLocation")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("VictimsName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("VictimId");

                    b.ToTable("Victims");
                });

            modelBuilder.Entity("Offence", b =>
                {
                    b.Property<int>("OffencesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OffencesId"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("CriminalId")
                        .HasColumnType("int");

                    b.Property<string>("OffenceName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("OffencesId");

                    b.HasIndex("CriminalId");

                    b.ToTable("Offences");
                });

            modelBuilder.Entity("DataProject.Models.OffenceVictim", b =>
                {
                    b.HasOne("DataProject.Models.Criminal", null)
                        .WithMany("OffenceVictims")
                        .HasForeignKey("CriminalId");

                    b.HasOne("Offence", "Offence")
                        .WithMany("OffenceVictims")
                        .HasForeignKey("OffencesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataProjectDb.Models.Victim", "Victim")
                        .WithMany("OffenceVictims")
                        .HasForeignKey("VictimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offence");

                    b.Navigation("Victim");
                });

            modelBuilder.Entity("Offence", b =>
                {
                    b.HasOne("DataProject.Models.Criminal", "Criminal")
                        .WithMany("Offences")
                        .HasForeignKey("CriminalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Criminal");
                });

            modelBuilder.Entity("DataProject.Models.Criminal", b =>
                {
                    b.Navigation("OffenceVictims");

                    b.Navigation("Offences");
                });

            modelBuilder.Entity("DataProjectDb.Models.Victim", b =>
                {
                    b.Navigation("OffenceVictims");
                });

            modelBuilder.Entity("Offence", b =>
                {
                    b.Navigation("OffenceVictims");
                });
#pragma warning restore 612, 618
        }
    }
}
