using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Secretary;
using Model;

namespace IS_Bolnica.Services
{
    public class PatientService
    {
        private List<Patient> patients = new List<Patient>();
        private PatientRepository patientRepository = new PatientRepository();
        

        public PatientService()
        {
            patients = GetPatients();
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        public void DeletePatient(Patient patient)
        {
            if (PatientExists(patient))
            {
                int index = FindPatientIndex(patient);
                patients.RemoveAt(index);
                patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
            }
        }

        public void EditPatient(Patient oldPatient, Patient newPatient)
        {
            int index = FindPatientIndex(oldPatient);
            patients.RemoveAt(index);
            patients.Add(newPatient);
            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        private bool PatientExists(Patient patient)
        {
            foreach (var p in patients)
            {
                if (p.Id.Equals(patient.Id))
                {
                    return true;
                }
            }

            return false;
        }

        private int FindPatientIndex(Patient patient)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patient.Id.Equals(patients[i].Id))
                {
                    return i;
                }
            }

            return -1;

        }

        public List<Patient> GetPatients()
        {
            return patientRepository.LoadFromFile("PatientRecordFileStorage.json");
        }

        public Patient findPatientById(string id)
        {
            Patient foundPatient = new Patient();
            foreach (Patient patient in patients)
            {
                if (patient.Id.Equals(id))
                {
                    foundPatient = patient;
                }
            }

            return foundPatient;
        }
    }
}
