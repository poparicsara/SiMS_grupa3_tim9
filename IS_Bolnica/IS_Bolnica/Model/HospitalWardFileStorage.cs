using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class HospitalWardFileStorage
    {
        private string fileName;
        private List<HospitalWard> wards;

        public HospitalWardFileStorage()
        {
            wards = new List<HospitalWard>();

            HospitalWard ward1 = new HospitalWard { Name = "Anesteziologija" };
            HospitalWard ward2 = new HospitalWard { Name = "Dermatologija" };
            HospitalWard ward3 = new HospitalWard { Name = "Interna medicina" };
            HospitalWard ward4 = new HospitalWard { Name = "Neurologija" };
            HospitalWard ward5 = new HospitalWard { Name = "Urologija" };
            HospitalWard ward6 = new HospitalWard { Name = "Ortopedija" };
            HospitalWard ward7 = new HospitalWard { Name = "Psihijatrija" };
            wards.Add(ward1);
            wards.Add(ward2);
            wards.Add(ward3);
            wards.Add(ward4);
            wards.Add(ward5);
            wards.Add(ward6);
            wards.Add(ward7);
        }

        public List<HospitalWard> GetAll()
        {
            return wards;
        }

        public void Save(HospitalWard ward)
        {
            wards.Add(ward);
        }

        public void saveToFile(List<HospitalWard> wards, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(wards, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<HospitalWard> loadFromFile(string fileName)
        {
            var wardList = new List<HospitalWard>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                wardList = (List<HospitalWard>)serializer.Deserialize(file, typeof(List<HospitalWard>));
            }

            return wardList;
        }
    }
}
