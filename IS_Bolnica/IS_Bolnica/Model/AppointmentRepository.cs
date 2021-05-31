﻿using System;
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
        public List<Appointment> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Appointment> appointments, string fileName)
        {
            string jsonString = JsonConvert.SerializeObject(appointments, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Appointment> LoadFromFile(string fileName)
        {
            var appointment = new List<Appointment>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                appointment = (List<Appointment>)serializer.Deserialize(file, typeof(List<Appointment>));
            }

            return appointment;
        }
    }
}
