using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class UrgentExaminationOptions : Page
    {
        private Specialization specialization = new Specialization();
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();
        private List<Appointment> appointments = new List<Appointment>();
        private UrgentAppointmentService urgentAppointmentService = new UrgentAppointmentService();


        public UrgentExaminationOptions(Appointment appointment, Specialization specialization)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.specialization = specialization;
            ExaminationOptions.ItemsSource = urgentAppointmentService.GetUrgentExaminationOptions(appointment, specialization);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addUrgentOperation(object sender, RoutedEventArgs e)
        {
            int i = ExaminationOptions.SelectedIndex;
            Appointment selectedAppointment = new Appointment();
            selectedAppointment = (Appointment)ExaminationOptions.SelectedItem;
            appointments = appointmentService.GetAppointments();

            if (i == -1)
            {
                MessageBox.Show("Niste izabrali pregled koji želite da zakažete!");
            }
            else
            {
                urgentAppointmentService.AddUrgentExamination(appointment, selectedAppointment);
            }
        }
    }
}
