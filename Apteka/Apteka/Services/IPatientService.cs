namespace Apteka.Services;

public interface IPatientService
{
    public Task<Object> ShowPrescriptions(int PatientId);
}