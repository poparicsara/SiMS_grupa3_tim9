using IS_Bolnica.Model;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class UrgentOperationOptionsWindow : Window
    {
        private Specialization specialization = new Specialization();
        private Appointment appointment = new Appointment();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private UrgentAppointmentService urgentAppointmentService = new UrgentAppointmentService();


        public UrgentOperationOptionsWindow(Appointment appointment, Specialization specialization)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.specialization = specialization;

            OperationOptions.ItemsSource = urgentAppointmentService.GetUrgentOperationOptions(appointment, specialization);
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

        //private void removeSelectedOperation(Operation operation)
        //{
        //    List<Operation> operations = operationsFileStorage.loadFromFile("operations.json");
        //    for (int k = 0; k < operations.Count; k++)
        //    {
        //        if (operations[k].Date.Equals(operation.Date) && operations[k].doctor.Id.Equals(operation.doctor.Id))
        //        {
        //            operations.RemoveAt(k);
        //        }
        //    }
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
        }

    }
}
