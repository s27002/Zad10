using Apteka.DTO;
using Apteka.Services;
using Microsoft.AspNetCore.Mvc;

namespace Apteka.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class PrescriptionController : ControllerBase
{
    private IPrescriptionService _prescriptionService;
    private IPatientService _patientService;
    
    public PrescriptionController(IPrescriptionService prescriptionService, IPatientService patientService)
    {
        _prescriptionService = prescriptionService;
        _patientService = patientService;
    }
    
    [HttpPut]
    public async Task<IActionResult> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        var check = await _prescriptionService.AddPrescription(newPrescriptionDto);

        if (check == -1)
        {
            return BadRequest("Lista leków nie może przekraczać 10");
        }
        if (check == 0)
        {
            return BadRequest("Data ważności nie może być mniejsza niż data wystawienia");
        }
        if (check == 1)
        {
            return BadRequest("Jeden z podanych leków nie istnieje");
        }
        
        return Ok("Dodano pomyślnie");
    }
    
    [HttpGet("{PatientId}")]
    public async Task<IActionResult> ShowPrescriptions(int PatientId)
    {
        var pre = await _patientService.ShowPrescriptions(PatientId);
        return Ok(pre);
    }
}