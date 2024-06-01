using Apteka.DTO;

namespace Apteka.Repository;

public interface IPrescriptionRepository
{
    public Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto);
}