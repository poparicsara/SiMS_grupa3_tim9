using System;
using System.Collections.Generic;
using System.IO;
using IS_Bolnica.IRepository;
using Newtonsoft.Json;


namespace IS_Bolnica.Model
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private string fileName = "Appointments.json";
        private List<Appointment> appointments = new List<Appointment>();

        public Appointment FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Appointment> appointments)
        {
            string jsonString = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public void Add(Appointment newEntity)
        {
            appointments = GetAll();
            appointments.Add(newEntity);
            SaveToFile(appointments);
        }

        public void Update(int index, Appointment newEntity)
        {
            appointments = GetAll();
            appointments.RemoveAt(index);
            appointments.Add(newEntity);
            SaveToFile(appointments);
        }

        public void Delete(int index)
        {
            appointments = GetAll();
            if (index == -1) return;
            appointments.RemoveAt(index);
            SaveToFile(appointments);
        }

        public List<Appointment> GetAll()
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
