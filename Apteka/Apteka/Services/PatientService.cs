using Apteka.Repository;

namespace Apteka.Services;

public class PatientService : IPatientService
{
    private IPatientRepository _patientRepository;

    public PatientService(IPatientRepository patientRepository)
    {
        _patientRepository = patientRepository;
    }

    public async Task<object> ShowPrescriptions(int PatientId)
    {
        return await _patientRepository.ShowPrescriptions(PatientId);
    }
}