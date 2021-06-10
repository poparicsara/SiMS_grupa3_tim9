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
            patientRepository.SaveToFile(patients);
        }

        public void DeletePatient(Patient patient)
        {
            patients = GetPatients();
            if (PatientExists(patient))
            {
                int index = FindPatientIndex(patient);
                patients.RemoveAt(index);
                patientRepository.SaveToFile(patients);
            }
        }

        public void EditPatient(Patient oldPatient, Patient newPatient)
        {
            patients = GetPatients();
            int index = FindPatientIndex(oldPatient);
            patients.RemoveAt(index);
            patients.Add(newPatient);
            patientRepository.SaveToFile(patients);
        }

        public void UnblockPatient(Patient patient)
        {
            patients = patientRepository.LoadFromFile();
            for (int i =  0; i < patients.Count; i++)
            {
                if (patient.Id.Equals(patients[i].Id))
                {
                    patients[i].isBlocked = false;
                    patients[i].Akcije = 0;
                }
            }
            patientRepository.SaveToFile(patients);
        }

        public List<Patient> GetBlockedPatients()
        {
            blockedPatients = new List<Patient>();
            patients = patientRepository.LoadFromFile();
            foreach (var patient in patients)
            {
                if (patient.isBlocked || patient.Akcije >= 6)
                {
                    blockedPatients.Add(patient);
                }
            }

            return blockedPatients;
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

        public Patient FindPatietnById(string id)
        {
            patients = patientRepository.LoadFromFile();
            foreach (var patient in patients)
            {
                if (patient.Id.Equals(id))
                {
                    return patient;
                }
            }

            return null;

        }

        public List<Patient> GetPatients()
        {
            return patientRepository.LoadFromFile();
        }

        public void SetPatientAllergens(List<Ingredient> ingredients, string id)
        {
            patients = patientRepository.LoadFromFile();
            foreach (var patient in patients)
            {
                if (patient.Id.Equals(id))
                {
                    patient.Ingredients = ingredients;
                }
            }
            patientRepository.SaveToFile(patients);
        }

        public List<Patient> GetSearchedPatients(string text)
        {
            patients = patientRepository.LoadFromFile();
            List<Patient> searchedPatients = new List<Patient>();
            foreach (Patient patient in patients)
            {
                if (ISearched(text, patient))
                {
                    searchedPatients.Add(patient);
                }
            }

            return searchedPatients;
        }

        private static bool ISearched(string text, Patient p)
        {
            return p.Name.ToLower().Contains(text) ||
                   p.Surname.ToLower().Contains(text) ||
                   p.Id.ToLower().StartsWith(text) ||
                   p.Username.ToLower().Contains(text);
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

    }
}
