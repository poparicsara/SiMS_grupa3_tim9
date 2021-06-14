using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.IRepository;
using Newtonsoft.Json;

namespace IS_Bolnica.Model
{
    class ShiftingRepository : IShiftingRepository
    {
        private List<Shifting> shiftings = new List<Shifting>();

        public List<Shifting> GetAll()
        {
            var shiftings = new List<Shifting>();
            using (StreamReader file = File.OpenText("Shiftings.json"))
            {
                var serializer = new JsonSerializer();
                shiftings = (List<Shifting>)serializer.Deserialize(file, typeof(List<Shifting>));
            }
            return shiftings;
        }

        public Shifting FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Shifting> entities)
        {
            string jsonString = JsonConvert.SerializeObject(shiftings, Formatting.Indented);
            File.WriteAllText("Shiftings.json", jsonString);
        }

        public void Add(Shifting newEntity)
        {
            shiftings = GetAll();
            shiftings.Add(newEntity);
            SaveToFile(shiftings);
        }

        public void Update(int index, Shifting newEntity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        public void EditShifting(int index)
        {
            shiftings = GetAll();
            Shifting s = shiftings.ElementAt(index);
            s.Executed = true;
            shiftings.RemoveAt(index);
            shiftings.Insert(index, s);
            SaveToFile(shiftings);
        }
    }
}
