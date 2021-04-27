using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IS_Bolnica
{
    public partial class AddMedicamentWindow : Window
    {
        private Notification notification = new Notification();
        private NotificationsFileStorage storage = new NotificationsFileStorage();
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public AddMedicamentWindow()
        {
            InitializeComponent();
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            notification.title = "Dodavanje leka u bazu";

            string content = idBox.Text + "\n" + nameBox.Text + "\n" + replacementBox.Text + "\n" + producerBox.Text;
            notification.content = content;

            if (toBox.SelectedIndex == 0)
            {
                notification.notificationType = NotificationType.doctor;
            }

            notification.Sender = UserType.director;

            notifications = storage.LoadFromFile("NotificationsFileStorage.json");
            notifications.Add(notification);
            storage.SaveToFile(notifications, "NotificationsFileStorage.json");

            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}
