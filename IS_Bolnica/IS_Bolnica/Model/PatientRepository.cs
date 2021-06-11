using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Collections.ObjectModel;
using IS_Bolnica.IRepository;
using IS_Bolnica;

namespace Model
{
    public class PatientRepository : IPatientRepository
    {
        private string fileName = "PatientRecordFileStorage.json";
        private List<Patient> patients = new List<Patient>();

        public void Delete(int index)
        {
            patients = GetAll();
            patients.RemoveAt(index);
            SaveToFile(patients);
        }

        public List<Patient> GetAll()
        {
            var patientsList = new List<Patient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                patientsList = (List<Patient>)serializer.Deserialize(file, typeof(List<Patient>));
            }

            return patientsList;
        }

        public Patient FindById(string id)
        {
            List<Patient> patients = GetAll();
            foreach (var patient in patients)
            {
                if (patient.Id.Equals(id))
                {
                    return patient;
                }
            }

            return null;
        }

        public void SaveToFile(List<Patient> entities)
        {
            string jsonString = JsonConvert.SerializeObject(entities, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(Patient newEntity)
        {
            patients = GetAll();
            patients.Add(newEntity);
            SaveToFile(patients);
        }

        public void SetPatientAllergents(List<Ingredient> ingredients, string id)
        {
            patients = GetAll();
            foreach (var patient in patients)
            {
                if (patient.Id.Equals(id))
                {
                    patient.Ingredients = ingredients;
                }
            }
            SaveToFile(patients);
        }

        public void UnblockPatient(Patient patient)
        {
            patients = GetAll();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patient.Id.Equals(patients[i].Id))
                {
                    patients[i].isBlocked = false;
                    patients[i].Akcije = 0;
                }
            }
            SaveToFile(patients);
        }

        public void Update(int index, Patient newEntity)
        {
            patients = GetAll();
            patients.RemoveAt(index);
            patients.Add(newEntity);
            SaveToFile(patients);
        }

    }
}