using Apteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Configurations;

public class MedicamentEfConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(k => k.IdMedicament);
        builder.Property(k => k.IdMedicament).UseIdentityColumn();
        builder.Property(f => f.Name).IsRequired().HasMaxLength(20);
        builder.Property(l => l.Description).IsRequired().HasMaxLength(100);
        builder.Property(l => l.Type).IsRequired().HasMaxLength(20);
        
        Medicament[] medicaments =
        {
            new Medicament{ IdMedicament = 1, Name = "Apap", Description = "Dla doroslych", Type = "Syrop"},
            new Medicament{ IdMedicament = 2, Name = "Mucosolwan", Description = "Dla dzieci", Type = "Syrop"}
        };
        builder.HasData(medicaments);
        builder.ToTable("Medicament");
    }
}
