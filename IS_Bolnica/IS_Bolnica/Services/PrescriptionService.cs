using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class PrescriptionService
    {
        private PrescriptionRepository prescriptionRepository = new PrescriptionRepository();
        private List<Prescription> prescriptions = new List<Prescription>();

        public PrescriptionService()
        {
            prescriptions = GetPrescriptions();
        }

        public void CreatePrescription(Prescription prescription)
        {
            prescriptions.Add(prescription);
            prescriptionRepository.SaveToFile(prescriptions);
        }

        public List<string> GetMedicationFromPrescription(string patientId)
        {
            List<string> patientsMedications = new List<string>();
            foreach (Prescription prescription in GetPrescriptions())
            {
                if (prescription.Patient.Id.Equals(patientId))
                {
                    patientsMedications.Add(prescription.Therapy.MedicationName);
                }
            }
            return patientsMedications;
        }

        private List<Prescription> GetPrescriptions()
        {
            return prescriptionRepository.LoadFromFile();
        }
    }
}
