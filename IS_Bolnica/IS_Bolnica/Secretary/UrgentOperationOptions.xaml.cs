using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class UrgentOperationOptions : Page
    {
        private Specialization specialization = new Specialization();
        private Appointment appointment = new Appointment();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private UrgentAppointmentService urgentAppointmentService = new UrgentAppointmentService();

        public UrgentOperationOptions(Appointment appointment, Specialization specialization)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.specialization = specialization;
            OperationOptions.ItemsSource = urgentAppointmentService.GetUrgentOperationOptions(appointment, specialization);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addUrgentExamination(object sender, RoutedEventArgs e)
        {
            int i = OperationOptions.SelectedIndex;
            List<Appointment> appoints = new List<Appointment>();
            appoints = OperationOptions.SelectedItems.Cast<Appointment>().ToList();
            List<Appointment> appointments = appointmentRepository.LoadFromFile();

            if (i == -1)
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da zakažete!");
            }
            else
            {
                urgentAppointmentService.AddUrgentOperation(appointment, appoints);
            }
        }
    }
}
