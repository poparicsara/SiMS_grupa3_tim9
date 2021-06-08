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

namespace IS_Bolnica.Secretary
{
    public partial class EditExaminationWindow : Window
    {
        private Appointment appointment = new Appointment();
        private Appointment oldAppointment = new Appointment();

        private DoctorService doctorService = new DoctorService();
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public EditExaminationWindow(Appointment oldAppointment)
        {
            InitializeComponent();
            this.oldAppointment = oldAppointment;

            doctorBox.ItemsSource = doctorService.GetDoctorNamesList();
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            appointment.Patient = findAttributesService.findPatient(idPatientBox.Text);
            string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
            string name = doctorNameAndSurname[0];
            string surname = doctorNameAndSurname[1];
            appointment.Doctor = findAttributesService.findDoctor(name, surname);
            DateTime datum = new DateTime();
            datum = (DateTime)dateBox.SelectedDate;
            int sat = Convert.ToInt32(hourBox.Text);
            int minut = Convert.ToInt32(minutesBox.Text);
            appointment.StartTime = new DateTime(datum.Year, datum.Month, datum.Day, sat, minut, 0);
            appointment.EndTime = appointment.StartTime.AddMinutes(30);
            appointment.Room = findAttributesService.findRoomByDoctor(appointment.Doctor);
            appointment.AppointmentType = AppointmentType.examination;
            
            appointmentService.EditAppointment(oldAppointment, appointment);

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
