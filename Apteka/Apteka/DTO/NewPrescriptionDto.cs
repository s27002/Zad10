namespace Apteka.DTO;

public class NewPrescriptionDto
{
    public PatientDto patient { get; set; }
    public int doctor { get; set; }
    public MedicamentDto[] medicaments { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
}