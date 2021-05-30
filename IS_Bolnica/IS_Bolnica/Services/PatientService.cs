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

        public List<string> GetPatientsAllergies(string patientId)
        {
            List<string> allergies = new List<string>();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(patientId))
                {
                    for (int j = 0; j < patients[i].Alergeni.Count; j++)
                    {
                        allergies.Add(patients[i].Alergeni[j].Name);
                        for (int k = 0; k < patients[i].Alergeni[j].IngredientsAllergens.Count; k++)
                        {
                            allergies.Add(patients[i].Alergeni[j].IngredientsAllergens[k].Name);
                            allergies.Add(patients[i].Alergeni[j].MedicamentsAllergens[k].Name);
                        }
                    }
                }
            }

            return allergies;
        }

        public bool IsPatientAllergic(string patientId, string allergen)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(patientId))
                {
                    for (int j = 0; j < patients[i].Alergeni.Count; j++)
                    {
                        if (patients[i].Alergeni[j].Name == allergen)
                        {
                            return true;
                        }
                        for (int k = 0; k < patients[i].Alergeni[j].IngredientsAllergens.Count; k++)
                        {
                            if (patients[i].Alergeni[j].IngredientsAllergens[k].Name == allergen
                                || patients[i].Alergeni[j].MedicamentsAllergens[k].Name == allergen)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
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
    }
}
