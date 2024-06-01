using Apteka.Context;
using Apteka.DTO;
using Apteka.Models;
using Microsoft.EntityFrameworkCore;

namespace Apteka.Repository;

public class PatientRepository : IPatientRepository
{
    public async Task<Object> ShowPrescriptions(int PatientId)
    {
        MasterContext mc = new MasterContext();
        var patient = mc.Patients.FirstOrDefault(e=> e.IdPatient == PatientId);
        var prescripts = mc.Prescriptions.Include(p => p.Doctor)
            .Include(p => p.Patient)
            .Include(p=>p.PrescriptionsMedicaments).ThenInclude(pm=>pm.Medicament).
            OrderBy(p=>p.DueDate);
        return new
        {
            PatientId = patient.IdPatient,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            Prescriptions = prescripts.Where(e=>e.IdPatient==PatientId).Select(e=>new PrescriptionDto()
            {
                PrescriptionId = e.IdPrescription,
                Date = e.Date,
                DueDate = e.DueDate,
                Medicaments = e.PrescriptionsMedicaments.Select(pm=>new SecondMedicamentDto
                {
                    IdMedicament = pm.IdMedicament,
                    Name = pm.Medicament.Name,
                    Dose = pm.Dose,
                    Description = pm.Medicament.Description
                }).ToList(),
                Doctor = new DoctorDto()
                {
                    IdDoctor = e.Doctor.IdDoctor,
                    FirstName = e.Doctor.FirstName,
                    LastName = e.Doctor.LastName
                }
            }).ToList()
        };
    }
}