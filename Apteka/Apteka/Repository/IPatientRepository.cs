namespace Apteka.Repository;

public interface IPatientRepository
{
    public Task<Object> ShowPrescriptions(int PatientId);
}