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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditExaminationWindow.xaml
    /// </summary>
    public partial class EditExaminationWindow : Window
    {
        private Examination examination;
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();

        public EditExaminationWindow(Examination examination)
        {
            InitializeComponent();
            this.examination = examination;

            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Ordinacija")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            room.ItemsSource = RoomNums;
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            List<Examination> examinations = new List<Examination>();
            ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
            ObservableCollection<Patient> Patients = new ObservableCollection<Patient>();
            PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

            examinations = examinationStorage.loadFromFile("Pregledi.json");
            for(int i = 0; i < examinations.Count; i++)
            {
                if (examinations[i].Date.Equals(examination.Date) &&
                                examinations[i].Patient.Id.Equals(examination.Patient.Id))
                {
                    examinations.RemoveAt(i);
                }
            }


            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int brojac = 0;
            for (int i = 0; i < Patients.Count; i++)
            {
                if (Patients[i].Id.Equals(idPatientBox.Text))
                {
                    examination.Patient = Patients[i];
                    brojac++;
                }

            }
            if (brojac == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            }

            string[] doctorNameAndSurname = doctor.Text.Split(' ');
            examination.Doctor = new Doctor();
            examination.Doctor.Name = doctorNameAndSurname[0];
            examination.Doctor.Surname = doctorNameAndSurname[1];

            DateTime datum = new DateTime();
            datum = (DateTime)dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minutesBox.Text);
            examination.Date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);

            examination.RoomRecord = new RoomRecord();
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                {
                    examination.RoomRecord = Rooms[i];
                }
            }

            examinations.Add(examination);
            examinationStorage.saveToFile(examinations, "Pregledi.json");

            Secretary.ExaminationListWindow elw = new ExaminationListWindow();
            elw.Show();
            this.Close();
        }

        private void cancelEditingExamination(object sender, RoutedEventArgs e)
        {
            Secretary.ExaminationListWindow elw = new ExaminationListWindow();
            elw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
