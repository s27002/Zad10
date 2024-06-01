using Apteka.DTO;

namespace Apteka.Services;

public interface IPrescriptionService
{
    public Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto);
}