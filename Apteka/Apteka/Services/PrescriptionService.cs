using Apteka.DTO;
using Apteka.Repository;

namespace Apteka.Services;

public class PrescriptionService : IPrescriptionService
{
    private IPrescriptionRepository _prescriptionRepository;

    public PrescriptionService(IPrescriptionRepository prescriptionRepository)
    {
        _prescriptionRepository = prescriptionRepository;
    }
    
    
    public async Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        return await _prescriptionRepository.AddPrescription(newPrescriptionDto);
    }
}