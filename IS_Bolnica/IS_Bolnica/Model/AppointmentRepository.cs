using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace IS_Bolnica.Model
{
    class AppointmentRepository
    {
        private string fileName = "Appointments.json";
        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Appointment> appointments)
        {
            string jsonString = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            File.WriteAllText("Appointments.json", jsonString);
        }

        public List<Appointment> LoadFromFile()
        {
            var appointment = new List<Appointment>();

            using (StreamReader file = File.OpenText("Appointments.json"))
            {
                var serializer = new JsonSerializer();
                appointment = (List<Appointment>)serializer.Deserialize(file, typeof(List<Appointment>));
            }

            return appointment;
        }
    }
}
