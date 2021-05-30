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
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorsWindows
{
    public partial class AddExaminationWindow : Window
    {
        public List<int> Hours { get; set; } = new List<int>();
        private Appointment appointment = new Appointment();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private PatientService patientService = new PatientService();
        private RoomService roomService = new RoomService();
        public AddExaminationWindow()
        {
            InitializeComponent();
            SetTimePicker();
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
            SetDataInTextFields();
            appointmentService.scheduleAppointment(appointment);

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();

            this.Close();
            
        }

        private void specijalistiRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            chooseSpecComboBox.ItemsSource = doctorService.getSpecializationNames();
        }

        private void opstaPraksaRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.getDoctorsNameSurname();
            chooseSpecComboBox.IsEnabled = false;
            chooseSpecComboBox.IsEditable = false;
        }

        private void opstaPraksaRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.removeDoctorsFromComboBox();
            chooseSpecComboBox.IsEnabled = true;
            chooseSpecComboBox.IsEditable = true;
        }

        private void specijalistiRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            doctorsComboBox.ItemsSource = doctorService.removeSpecialistsFromComboBox();
        }

        private void jmbgTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            healthCardNumberTxt.Text = patientService.findPatientById(jmbgTxt.Text).HealthCardNumber;

        }
        private void showDoctorOrdination()
        {
            roomTxt.Text = doctorService.showDoctorsOrdination(doctorsComboBox.SelectedItem.ToString()).ToString();
        }

        private void showDoctors(string specializationName)
        {
            doctorsComboBox.ItemsSource = doctorService.setSpecialistsInComboBox(specializationName);
        }

        private void doctorsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
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
        private void SetTimePicker()
        {
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

        private void SetDataInTextFields()
        {
            appointment.Doctor = doctorService.findDoctorByName(doctorsComboBox.SelectedItem.ToString());
            appointment.Patient = patientService.findPatientById(jmbgTxt.Text);
            DateTime date = new DateTime();
            date = (DateTime)datePicker.SelectedDate;
            int hour = Convert.ToInt32(hourBox.Text);
            int minute = Convert.ToInt32(minuteBox.Text);
            appointment.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
            appointment.Room = new Room();
            appointment.AppointmentType = AppointmentType.examination;
            appointment.Room = roomService.FindOrdinationById(appointment.Doctor.Ordination);
        }
    }
}
