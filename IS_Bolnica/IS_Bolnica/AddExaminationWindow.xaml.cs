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
        private int ordination = 0;
        public AddExaminationWindow(int doctorsOrdination)
        {
            InitializeComponent();

            ordination = doctorsOrdination;

            roomTxt.Text = ordination.ToString();
            roomTxt.IsEnabled = false;
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorWindow doctorWindow = new DoctorWindow(ordination);
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            RoomRecord room = new RoomRecord();
            RoomPurpose purpose = new RoomPurpose();
            patient.Name = patientNameTxt.Text;
            patient.Surname = patientSurnameTxt.Text;
            purpose.Name = roomTxt.Text;
            room.roomPurpose = purpose;

            Examination examination = new Examination
            {
                Patient = patient,
                RoomRecord = room,
                Date = DateTime.Parse(dateTxt.Text)
            };

            ExaminationsRecordFileStorage storage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = storage.loadFromFile("examinations.json");
            examinations.Add(examination);
            storage.saveToFile(examinations, "examinations.json");

            DoctorWindow doctorWindow = new DoctorWindow(ordination);
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();

            this.Close();
        }
    }
}
