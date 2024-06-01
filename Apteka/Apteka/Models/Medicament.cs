﻿namespace Apteka.Models;

public class Medicament
{
    public int IdMedicament { get; set; } 
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public virtual ICollection<PrescriptionMedicament> PrescriptionsMedicaments { get; set; } = new List<PrescriptionMedicament>();
}