using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.GUI.Director.ViewModel
{
    public class SelectedNotificationViewModel
    {
        public string Title { get; set; }
        public string Sender { get; set; }
        public string Content { get; set; }

        public SelectedNotificationViewModel(Notification notification)
        {
            Title = notification.Title;
            Sender = notification.Sender.ToString();
            Content = notification.Content;
        }

    }
}
