using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Patterns;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddExamination : Page
    {
        private Page previousPage;
        private Appointment appointment = new Appointment();
        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();


        public AddExamination(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();

        }

        private void setAppointmentsAttributes()
        {
            appointment.DurationInMins = 30;
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
            appointment.EndTime = appointment.StartTime.AddMinutes(appointment.DurationInMins);
            appointment.Room = findAttributesService.findRoomByDoctor(appointment.Doctor);
            appointment.IsUrgent = false;
            appointment.GuestUser = new GuestUser();
            appointment.PostponedDate = new DateTime(); 
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            if (doctorBox.SelectedIndex == -1 || dateBox.SelectedDate == null || idPatientBox.Text == "" 
                || hourBox.SelectedIndex == -1 || minutesBox.SelectedIndex == -1)
            {
                MessageBox.Show("Morate da popunite sva polja!");
                return;
            }

            setAppointmentsAttributes();

            if (!isOkay(appointment)) return;
            AddAppointmentTemplate template = new Patterns.AddExamination(appointment);
            template.AddAppointment();

            ExaminationList el = new ExaminationList(this);
            this.NavigationService.Navigate(el);

        }

        private bool isOkay(Appointment appointment)
        {
            if (!appointmentService.isDoctorsShift(appointment))
            {
                MessageBox.Show("It's not doctors shift!");
                return false;
            }
            else if (!appointmentService.isDoctorFree(appointment))
            {
                MessageBox.Show("Doctor already have scheduled appointment!");
                return false;
            } else if (appointmentService.isPatientFree(appointment))
            {
                MessageBox.Show("Patient is not available");
                return false;
            }
            else if (appointmentService.isRoomFree(appointment))
            {
                MessageBox.Show("Room is not available!");
                return false;
            }

            return true;
        }

        private void cancelAddingExamination(object sender, RoutedEventArgs e)
        {
            ExaminationList el = new ExaminationList(this);
            this.NavigationService.Navigate(el);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }
    }
}
