using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class FeedbackService
    {
        private FeedbackRepository repo = new FeedbackRepository();
        private List<Feedback> feedbacks = new List<Feedback>();

        public FeedbackService()
        {

        }

        public void SaveFeedback(Feedback feedback)
        {
            feedbacks = repo.LoadFromFile();
            feedbacks.Add(feedback);
            repo.SaveToFile(feedbacks);
        }

    }
}
