using Apteka.Context;
using Apteka.DTO;
using Apteka.Models;

namespace Apteka.Repository;

public class PrescriptionRepository : IPrescriptionRepository
{
    public async Task<int> AddPrescription(NewPrescriptionDto newPrescriptionDto)
    {
        MasterContext mc = new MasterContext();
        
        if (newPrescriptionDto.medicaments.Length > 10)
        {
            return -1;
        }

        if (newPrescriptionDto.DueDate < newPrescriptionDto.Date)
        {
            return 0;
        }
        
        foreach(MedicamentDto med in newPrescriptionDto.medicaments)
        {
            if (!mc.Medicaments.Any(e => e.IdMedicament == med.IdMedicament))
            {
                return 1;
            }
        }
        
        var patient = mc.Patients.FirstOrDefault(e => e.IdPatient == newPrescriptionDto.patient.IdPatient);
        if (patient == null)
        {
            patient = new Patient
            {
                FirstName = newPrescriptionDto.patient.FirstName,
                LastName = newPrescriptionDto.patient.LastName
            };
            mc.Patients.Add(patient);
            await mc.SaveChangesAsync();
            mc.Patients.FirstOrDefault(e => e.IdPatient == newPrescriptionDto.patient.IdPatient);
        }

        Prescription prescription = new Prescription
        {
            Date = newPrescriptionDto.Date,
            DueDate = newPrescriptionDto.DueDate,
            IdDoctor = newPrescriptionDto.doctor,
            IdPatient = patient.IdPatient
        };
        mc.Prescriptions.Add(prescription);
        await mc.SaveChangesAsync();
        
        foreach (MedicamentDto med in newPrescriptionDto.medicaments)
        {
            PrescriptionMedicament prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = prescription.IdPrescription,
                Dose = int.Parse(med.Dose),
                Details = med.Description
            };
            mc.PrescriptionMedicaments.Add(prescriptionMedicament);
        }

        mc.SaveChangesAsync();
        return 2;
    }
}