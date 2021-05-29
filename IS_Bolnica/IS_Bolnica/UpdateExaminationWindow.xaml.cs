using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.DoctorsWindows
{
    public partial class UpdateExaminationWindow : Window
    {
        private Appointment examination;
        public List<int> Hours { get; set; } = new List<int>();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private PatientService patientService = new PatientService();
        private RoomService roomService = new RoomService();
        public UpdateExaminationWindow(int selectedIndex, List<Appointment> loggedDoctorExaminations)

        {
            InitializeComponent();

            List<Appointment> examinations = loggedDoctorExaminations;
            this.examination = examinations.ElementAt(selectedIndex);

            datePicker.SelectedDate = examination.StartTime;
            hourBox.SelectedItem = examination.StartTime.Hour;
            minuteBox.SelectedItem = examination.StartTime.Minute;
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            jmbgTxt.Text = examination.Patient.Id;
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;
            roomTxt.Text = examination.Doctor.Ordination.ToString();

            if (examination.Doctor.Specialization.Name == " ")
            {
                opstaPraksaRadioBtn.IsChecked = true;
                specijalistiRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
            }
            if (examination.Doctor.Specialization.Name != " ")
            {
                specijalistiRadioBtn.IsChecked = true;
                opstaPraksaRadioBtn.IsChecked = false;
                doctorsComboBox.SelectedItem = examination.Doctor.Name + ' ' + examination.Doctor.Surname;
                chooseSpecComboBox.SelectedItem = examination.Doctor.Specialization.Name;
            }

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            appointmentService.DeleteAppointment(examination);

            examination.Doctor = doctorService.findDoctorByName(doctorsComboBox.SelectedItem.ToString());
            examination.Patient = patientService.findPatientById(jmbgTxt.Text);
            DateTime date = new DateTime();
            date = (DateTime) datePicker.SelectedDate;
            int hour = Convert.ToInt32(hourBox.Text);
            int minute = Convert.ToInt32(minuteBox.Text);
            examination.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            examination.RoomRecord = new RoomRecord();
            examination.RoomRecord = roomService.FindOrdinationById(examination.Doctor.Ordination);
            appointmentService.scheduleAppointment(examination);

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();
            this.Close();

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

        private void specijalistiRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            chooseSpecComboBox.ItemsSource = doctorService.getSpecializationNames();
        }

        private void opstaPraksaRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.getDoctorsNameSurname();
        }

        private void opstaPraksaRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.removeDoctorsFromComboBox();
        }

        private void specijalistiRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.removeSpecialistsFromComboBox();
        }

        private void showDoctorOrdination()
        {
            roomTxt.Text = doctorService.showDoctorsOrdination(doctorsComboBox.SelectedItem.ToString()).ToString();
        }

        private void showDoctors(string specializationName)
        {
            doctorsComboBox.ItemsSource = doctorService.setSpecialistsInComboBox(specializationName);
        }

        private void doctorsComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (doctorsComboBox.SelectedItem != null)
            {
                showDoctorOrdination();
            }
            else if (doctorsComboBox.SelectedItem == null)
            {
                roomTxt.Text = " ";
            }
        }

        private void chooseSpecComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctorsComboBox.ItemsSource = null;

            showDoctors(chooseSpecComboBox.SelectedItem.ToString());
        }
    }

}