using Apteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Configurations;

public class PrescriptionEfConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(k => k.IdPrescription);
        builder.Property(k => k.IdPrescription).UseIdentityColumn();

        builder.Property(k => k.Date).IsRequired();
        builder.Property(k => k.DueDate).IsRequired();
        
        builder.HasOne(d=>d.Doctor)
            .WithMany(p=>p.Prescriptions)
            .HasForeignKey(d => d.IdDoctor)
            .HasConstraintName("Prescription_Doctor")
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(p=>p.Patient)
            .WithMany(p=>p.Prescriptions)
            .HasForeignKey(p => p.IdPatient)
            .HasConstraintName("Prescription_Patient")
            .OnDelete(DeleteBehavior.Restrict);

        Prescription prescription = new Prescription
        {
            IdPrescription = 1,
            Date = DateTime.Parse("10-10-2020"),
            DueDate = DateTime.Parse("10-10-2021"),
            IdPatient = 1,
            IdDoctor = 1

        };
        builder.HasData(prescription);
        builder.ToTable("Prescription");
    }
}