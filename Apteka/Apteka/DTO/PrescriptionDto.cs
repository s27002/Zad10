using Apteka.Models;

namespace Apteka.DTO;

public class PrescriptionDto
{
    public int PrescriptionId { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public List<SecondMedicamentDto> Medicaments { get; set; }
    public DoctorDto Doctor { get; set; }
}