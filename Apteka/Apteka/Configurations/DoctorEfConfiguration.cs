using Apteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Configurations;

public class DoctorEfConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(k => k.IdDoctor);
        builder.Property(k => k.IdDoctor).UseIdentityColumn();
        builder.Property(f => f.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(l => l.LastName).IsRequired().HasMaxLength(50);
        
        Doctor[] doctors =
        {
            new Doctor{ IdDoctor = 1, FirstName = "Alojzy", LastName = "Szpak"},
            new Doctor{ IdDoctor = 2, FirstName = "Anna", LastName = "Belg"}
        };
        builder.HasData(doctors);
        builder.ToTable("Doctor");
    }
}