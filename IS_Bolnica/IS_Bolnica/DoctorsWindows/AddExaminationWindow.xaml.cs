using Model;
using System;
using System.Collections.Generic;
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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class AddExaminationWindow : Window
    {
        public AddExaminationWindow()
        {
            InitializeComponent();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            DateTime dateTime = DateTime.Parse(dateTxt.Text);
            String roomName = roomTxt.Text;
            String patientNameSurname = patientTxt.Text;

            DoctorWindow doctorWindow = new DoctorWindow();
            //doctorWindow.Examinations.Add(new Examination { Date = dateTime, RoomName = roomName, NameSurname = patientNameSurname });

            doctorWindow.dataGridExaminations.Items.Add(new Examination { Date = dateTime, RoomName = roomName, NameSurname = patientNameSurname });

            this.Close();
        }
    }
}
