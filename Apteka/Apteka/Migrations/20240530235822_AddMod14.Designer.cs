﻿// <auto-generated />
using System;
using Apteka.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Apteka.Migrations
{
    [DbContext(typeof(MasterContext))]
    [Migration("20240530235822_AddMod14")]
    partial class AddMod14
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Apteka.Models.Doctor", b =>
                {
                    b.Property<int>("IdDoctor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDoctor"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdDoctor");

                    b.ToTable("Doctor", (string)null);

                    b.HasData(
                        new
                        {
                            IdDoctor = 1,
                            FirstName = "Alojzy",
                            LastName = "Szpak"
                        },
                        new
                        {
                            IdDoctor = 2,
                            FirstName = "Anna",
                            LastName = "Belg"
                        });
                });

            modelBuilder.Entity("Apteka.Models.Medicament", b =>
                {
                    b.Property<int>("IdMedicament")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMedicament"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdMedicament");

                    b.ToTable("Medicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdMedicament = 1,
                            Description = "Dla doroslych",
                            Name = "Apap",
                            Type = "Syrop"
                        },
                        new
                        {
                            IdMedicament = 2,
                            Description = "Dla dzieci",
                            Name = "Mucosolwan",
                            Type = "Syrop"
                        });
                });

            modelBuilder.Entity("Apteka.Models.Patient", b =>
                {
                    b.Property<int>("IdPatient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPatient"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdPatient");

                    b.ToTable("Patient", (string)null);

                    b.HasData(
                        new
                        {
                            IdPatient = 1,
                            FirstName = "Karl",
                            LastName = "Stein"
                        },
                        new
                        {
                            IdPatient = 2,
                            FirstName = "George",
                            LastName = "Danton"
                        });
                });

            modelBuilder.Entity("Apteka.Models.Prescription", b =>
                {
                    b.Property<int>("IdPrescription")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrescription"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdDoctor")
                        .HasColumnType("int");

                    b.Property<int>("IdPatient")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription");

                    b.HasIndex("IdDoctor");

                    b.HasIndex("IdPatient");

                    b.ToTable("Prescription", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            Date = new DateTime(2020, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DueDate = new DateTime(2021, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IdDoctor = 1,
                            IdPatient = 1
                        });
                });

            modelBuilder.Entity("Apteka.Models.PrescriptionMedicament", b =>
                {
                    b.Property<int>("IdPrescription")
                        .HasColumnType("int");

                    b.Property<int>("IdMedicament")
                        .HasColumnType("int");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Dose")
                        .HasColumnType("int");

                    b.HasKey("IdPrescription", "IdMedicament")
                        .HasName("PrescriptionMedicament_pk");

                    b.HasIndex("IdMedicament");

                    b.ToTable("PrescriptionMedicament", (string)null);

                    b.HasData(
                        new
                        {
                            IdPrescription = 1,
                            IdMedicament = 1,
                            Details = "Ostroznie",
                            Dose = 5
                        });
                });

            modelBuilder.Entity("Apteka.Models.Prescription", b =>
                {
                    b.HasOne("Apteka.Models.Doctor", "Doctor")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdDoctor")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Prescription_Doctor");

                    b.HasOne("Apteka.Models.Patient", "Patient")
                        .WithMany("Prescriptions")
                        .HasForeignKey("IdPatient")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("Prescription_Patient");

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Apteka.Models.PrescriptionMedicament", b =>
                {
                    b.HasOne("Apteka.Models.Medicament", "Medicament")
                        .WithMany("PrescriptionsMedicaments")
                        .HasForeignKey("IdMedicament")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicament_Medicament");

                    b.HasOne("Apteka.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionsMedicaments")
                        .HasForeignKey("IdPrescription")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired()
                        .HasConstraintName("PrescriptionMedicament_Prescription");

                    b.Navigation("Medicament");

                    b.Navigation("Prescription");
                });

            modelBuilder.Entity("Apteka.Models.Doctor", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Apteka.Models.Medicament", b =>
                {
                    b.Navigation("PrescriptionsMedicaments");
                });

            modelBuilder.Entity("Apteka.Models.Patient", b =>
                {
                    b.Navigation("Prescriptions");
                });

            modelBuilder.Entity("Apteka.Models.Prescription", b =>
                {
                    b.Navigation("PrescriptionsMedicaments");
                });
#pragma warning restore 612, 618
        }
    }
}