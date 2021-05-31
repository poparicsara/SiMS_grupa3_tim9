using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class MedicamentRepository
    {
        private List<Medicament> meds;

        public MedicamentRepository()
        {
            meds = GetMedicaments();
        }

        public void AddMedicament(Medicament newMedicament)
        {
            meds.Add(newMedicament);
            saveToFile(meds);
        }

        public void saveToFile(List<Medicament> medicaments)
        {
            string jsonString = JsonConvert.SerializeObject(medicaments, Formatting.Indented);
            File.WriteAllText("Lekovi.json", jsonString);
        }

        public List<Medicament> GetMedicaments()
        {
            var medicaments = new List<Medicament>();

            using (StreamReader file = File.OpenText("Lekovi.json"))
            {
                var serializer = new JsonSerializer();
                medicaments = (List<Medicament>)serializer.Deserialize(file, typeof(List<Medicament>));
            }

            return medicaments;
        }
    }
}
