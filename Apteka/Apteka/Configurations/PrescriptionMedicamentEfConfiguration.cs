using Apteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Configurations;

public class PrescriptionMedicamentEfConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(k => new { k.IdPrescription, k.IdMedicament }).HasName("PrescriptionMedicament_pk");
        builder.Property(e => e.Details).IsRequired().HasMaxLength(100);
        
        builder.HasOne(m=>m.Medicament)
            .WithMany(p=>p.PrescriptionsMedicaments)
            .HasForeignKey(d => d.IdMedicament)
            .HasConstraintName("PrescriptionMedicament_Medicament")
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(m=>m.Prescription)
            .WithMany(p=>p.PrescriptionsMedicaments)
            .HasForeignKey(d => d.IdPrescription)
            .HasConstraintName("PrescriptionMedicament_Prescription")
            .OnDelete(DeleteBehavior.Restrict);

        PrescriptionMedicament prescriptionMedicament = new PrescriptionMedicament
        {
            IdMedicament = 1,
            IdPrescription = 1,
            Dose = 5,
            Details = "Ostroznie"
        };
        builder.HasData(prescriptionMedicament);
        builder.ToTable("PrescriptionMedicament");

    }
}