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

        }

        public List<string> getMedicationFromPrescription(string patientId)
        {
            List<string> patientsMedications = new List<string>();
            foreach (Prescription prescription in getPrescriptions())
            {
                if (prescription.Patient.Id.Equals(patientId))
                {
                    patientsMedications.Add(prescription.Therapy.MedicationName);
                }
            }
            return patientsMedications;
        }

        private List<Prescription> getPrescriptions()
        {
            return prescriptionRepository.loadFromFile("prescriptions.json");
        }

        public List<Prescription> getPatientPrescriptions(String username) {
            prescriptions = getPrescriptions();
            List<Prescription> patientPrescriptions = new List<Prescription>();

            foreach (Prescription prescription in prescriptions) {
                if (prescription.Patient.Username.Equals(username))
                    patientPrescriptions.Add(prescription);
            }

            return patientPrescriptions;
        }
    }
}
