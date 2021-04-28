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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class AddExaminationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Patient patient = new Patient();
        private Examination examination = new Examination();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        public List<Examination> Examinations { get; set; } = new List<Examination>();
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public AddExaminationWindow()
        {
            InitializeComponent();

            Rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name == "Ordinacija")
                {
                    RoomId.Add(room.Id);
                }
            }

            roomComboBox.ItemsSource = RoomId;
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorWindow doctorWindow = new DoctorWindow();
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        { 
            Examinations = examinationStorage.loadFromFile("examinations.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");

            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Patient patient in Patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    examination.Patient = patient;
                    cnt++;
                }
            }

            if ((patientNameAndSurname[0] != examination.Patient.Name) || (patientNameAndSurname[1] != examination.Patient.Surname))
            {
                MessageBox.Show("Pogresno ime ili prezime!");
            } 
            else if (cnt == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            } else
            {
                examination.Date = DateTime.Parse(dateTxt.Text);
                examination.RoomRecord = new RoomRecord();

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == Convert.ToInt32(roomComboBox.SelectedItem))
                    {
                        examination.RoomRecord = room;
                    }
                }

                Examinations.Add(examination);
                examinationStorage.saveToFile(Examinations, "examinations.json");

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.dataGridExaminations.Items.Refresh();
                doctorWindow.Show();

                this.Close();
            }


        }
    }
}
