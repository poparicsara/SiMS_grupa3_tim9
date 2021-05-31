using System.Collections.Generic;
using System.Windows;
using Model;

namespace IS_Bolnica.Services
{
    public class PatientService
    {
        private List<Patient> patients = new List<Patient>();
        private PatientRepository patientRepository = new PatientRepository();
        private List<Patient> blockedPatients = new List<Patient>();
        

        public PatientService()
        {
            patients = GetPatients();
        }

        public void AddPatient(Patient patient)
        {
            patients = GetPatients();
            patients.Add(patient);
            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        public void DeletePatient(Patient patient)
        {
            patients = GetPatients();
            if (PatientExists(patient))
            {
                int index = FindPatientIndex(patient);
                patients.RemoveAt(index);
                patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
            }
        }

        public void EditPatient(Patient oldPatient, Patient newPatient)
        {
            patients = GetPatients();
            int index = FindPatientIndex(oldPatient);
            patients.RemoveAt(index);
            patients.Add(newPatient);
            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        public void UnblockPatient(Patient patient)
        {
            patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
            for (int i =  0; i < patients.Count; i++)
            {
                if (patient.Id.Equals(patients[i].Id))
                {
                    patients[i].isBlocked = false;
                    patients[i].Akcije = 0;
                }
            }
            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        public List<Patient> GetBlockedPatients()
        {
            patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
            foreach (var patient in patients)
            {
                if (patient.isBlocked)
                {
                    blockedPatients.Add(patient);
                }
            }

            return patients;
        }

        public bool PatientExists(Patient patient)
        {
            patients = GetPatients();
            foreach (var p in patients)
            {
                if (p.Id.Equals(patient.Id))
                {
                    return true;
                }
            }

            return false;
        }

        public bool PatientIdExists(string id)
        {
            patients = GetPatients();
            foreach (var p in patients)
            {
                if (p.Id.Equals(id))
                {
                    return true;
                }
            }
            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return false;
        }

        private int FindPatientIndex(Patient patient)
        {
            patients = GetPatients();
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
