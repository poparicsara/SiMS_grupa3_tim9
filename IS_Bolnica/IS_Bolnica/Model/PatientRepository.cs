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

        public void Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Patient FindPatientById(string id)
        {
            throw new NotImplementedException();
        }

        public int FindPatientIndex(Patient patient)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetBlockPatients()
        {
            throw new NotImplementedException();
        }

        public Patient FindById(string id)
        {
            throw new NotImplementedException();
        }

        public List<Patient> GetSearchedPatients(string text)
        {
            throw new NotImplementedException();
        }

        public bool PatientExists(Patient patient)
        {
            throw new NotImplementedException();
        }

        public bool PatientIdExists(string id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Patient> entities)
        {
            throw new NotImplementedException();
        }

        public void SetPatientAllergents(List<Ingredient> ingredients, string id)
        {
            throw new NotImplementedException();
        }

        public void UnblockPatient(Patient patient)
        {
            throw new NotImplementedException();
        }

        public void Update(Patient oldEntity, Patient newEntity)
        {
            throw new NotImplementedException();
        }


        /*public List<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Patient> patients)
        {
            string jsonString = JsonConvert.SerializeObject(patients, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Patient> LoadFromFile()
        {
            var patientsList = new List<Patient>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                patientsList = (List<Patient>)serializer.Deserialize(file, typeof(List<Patient>));
            }

            return patientsList;
        }*/

    }
}