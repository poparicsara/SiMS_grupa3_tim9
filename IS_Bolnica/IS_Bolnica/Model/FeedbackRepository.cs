using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace IS_Bolnica.Model
{
    class FeedbackRepository
    {
        private string fileName = "feedback.json";

        public List<Feedback> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveToFile(List<Feedback> feedbacks)
        {
            string jsonString = JsonConvert.SerializeObject(feedbacks, Formatting.Indented);
            File.WriteAllText(fileName, jsonString);
        }

        public List<Feedback> LoadFromFile()
        {
            var feedbacks = new List<Feedback>();

            using (StreamReader file = File.OpenText(fileName))
            {
                var serializer = new JsonSerializer();
                feedbacks = (List<Feedback>)serializer.Deserialize(file, typeof(List<Feedback>));
            }

            return feedbacks;
        }
    }
}
