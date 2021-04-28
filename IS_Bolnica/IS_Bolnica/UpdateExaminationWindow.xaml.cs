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
    public partial class UpdateExaminationWindow : Window
    {
        private int selectedExamination;
        private Examination examination;
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public UpdateExaminationWindow(int selectedIndex)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");
            Rooms = roomStorage.loadFromFile("Sobe.json");

            this.examination = examinations.ElementAt(selectedIndex);

            dateTxt.Text = examination.Date.ToString("dd.MM.yyyy hh.mm");
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            jmbgTxt.Text = examination.Patient.Id;
      
            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name.Equals("Ordinacija"))
                {
                    RoomId.Add(room.Id);
                }
            }

            roomComboBox.ItemsSource = RoomId;
            selectedExamination = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

            ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();
            PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

            for (int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].Date.Equals(examination.Date) && examinations[i].Patient.Id.Equals(examination.Patient.Id))
                {
                    examinations.RemoveAt(i);
                }
            }

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
                MessageBox.Show("Pacijent sa unetim JMBG-om ne postoji!");
            }
            else
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

                examinations.Add(examination);
                examinationsRecordFileStorage.saveToFile(examinations, "examinations.json");

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.dataGridExaminations.Items.Refresh();
                doctorWindow.Show();
                this.Close();
            }
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Update examination", MessageBoxButton.YesNo);

            switch (messageBox)
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
    }
    
}
