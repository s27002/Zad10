using Apteka.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Apteka.Configurations;

public class PatientEfConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(k => k.IdPatient);
        builder.Property(k => k.IdPatient).UseIdentityColumn();
        builder.Property(f => f.FirstName).IsRequired().HasMaxLength(20);
        builder.Property(l => l.LastName).IsRequired().HasMaxLength(50);
        
        Patient[] patients =
        {
            new Patient{ IdPatient = 1, FirstName = "Karl", LastName = "Stein"},
            new Patient{ IdPatient = 2, FirstName = "George", LastName = "Danton"}
        };
        builder.HasData(patients);
        builder.ToTable("Patient");
    }
}