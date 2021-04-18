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
    /// Interaction logic for AddExaminationWindow.xaml
    /// </summary>
    public partial class AddExaminationWindow : Window
    {

        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();

        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        public List<Examination> Examinations { get; set; } = new List<Examination>();
        private Examination examination = new Examination();
        private Patient patient = new Patient();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public ObservableCollection<Patient> Patients { get; set; } = new ObservableCollection<Patient>();

        public AddExaminationWindow()
        {
            InitializeComponent();
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for(int i = 0; i < Rooms.Count; i++)
            {
                RoomNums.Add(Rooms[i].Id);
            }
            room.ItemsSource = RoomNums;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void cancelAddingExamination(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            Examinations = examinationStorage.loadFromFile("Pregledi.json");
            examination.durationInMinutes = 30;

            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            int brojac = 0;
            for(int i = 0; i < Patients.Count; i++)
            {
                if(Patients[i].Id.Equals(idPatientBox.Text))
                {
                    examination.Patient = Patients[i];
                    brojac++;
                }

            }
            if(brojac == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            }

            string[] doctorNameAndSurname = doctor.Text.Split(' ');
            examination.doctor = new Doctor();
            examination.doctor.Name = doctorNameAndSurname[0];
            examination.doctor.Surname = doctorNameAndSurname[1];

            DateTime datum = new DateTime();
            datum = (DateTime) dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minutesBox.Text);
            examination.date = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);

            examination.RoomRecord = new RoomRecord();
            for(int i = 0; i < Rooms.Count; i++)
            {
                if(Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                {
                    examination.RoomRecord = Rooms[i];
                }
            }

            Examinations.Add(examination);
            examinationStorage.saveToFile(Examinations, "Pregledi.json");

            Secretary.ExaminationListWindow elw = new Secretary.ExaminationListWindow();
            elw.Show();
            this.Close();
        }
    }
}
