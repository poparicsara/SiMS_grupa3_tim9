using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class EditExamination : Page
    {
        private Page previousPage;
        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public EditExamination(Appointment oldAppointment, Page previousPage)
        {
            InitializeComponent();
            this.oldAppointment = oldAppointment;
            this.previousPage = previousPage;
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private bool isAllFilled()
        {
            if (idPatientBox.Text == "" || doctorBox.SelectedIndex == -1 || dateBox.SelectedDate == null )
            {
                MessageBox.Show("Morate da popunite sva polja!");
                return false;
            }

            return true;
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            appointment.Patient = findAttributesService.FindPatient(idPatientBox.Text);
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.FindDoctor(name, surname);
            DateTime datum = new DateTime();
            datum = (DateTime)dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minutesBox.Text);
            appointment.StartTime = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);
            appointment.EndTime = appointment.StartTime.AddMinutes(30);
            appointment.Room = findAttributesService.findRoomByDoctor(appointment.Doctor);
            appointment.AppointmentType = AppointmentType.examination;

            appointmentService.EditAppointment(oldAppointment, appointment);

            ExaminationList el = new ExaminationList(this);
            this.NavigationService.Navigate(el);
        }

        private void cancelEditingExamination(object sender, RoutedEventArgs e)
        {
            ExaminationList el = new ExaminationList(this);
            this.NavigationService.Navigate(el);
        }
    }
}
