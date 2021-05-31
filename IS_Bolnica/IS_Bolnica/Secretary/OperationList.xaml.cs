using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class OperationList : Page
    {
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();

        public OperationList()
        {
            InitializeComponent();
            this.DataContext = this;
            OperationListGrid.ItemsSource = appointmentService.getOperations();

        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            int i = OperationListGrid.SelectedIndex;

            appointment = (Appointment)OperationListGrid.SelectedItem;


            if (!isSelected(i))
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da izmenite!");
            }
            else
            {
                EditOperation eo = new EditOperation(appointment);
                setElementsEO(eo, appointment);
                this.NavigationService.Navigate(eo);
            }

        }

        private void setElementsEO(EditOperation eow, Appointment appointment)
        {
            eow.patientId.Text = appointment.Patient.Id;
            eow.hourBoxStart.Text = appointment.StartTime.Hour.ToString();
            eow.minutesBoxStart.Text = appointment.StartTime.Minute.ToString();
            eow.doctorBox.Text = appointment.Doctor.Name + " " + appointment.Doctor.Surname;
            eow.date.SelectedDate = new DateTime(appointment.StartTime.Year, appointment.StartTime.Month, appointment.StartTime.Day);
            eow.room.Text = appointment.Room.Id.ToString();
            int hours = appointment.DurationInMins / 60;
            int mins = appointment.DurationInMins % 60;
            eow.hourBoxEnd.Text = hours.ToString();
            eow.minuteBoxEnd.Text = mins.ToString();
        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            AddOperation ao = new AddOperation();
            this.NavigationService.Navigate(ao);
        }

        private bool isSelected(int i)
        {
            if (i == -1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void deleteOperation(object sender, RoutedEventArgs e)
        {
            int i = OperationListGrid.SelectedIndex;

            appointment = (Appointment)OperationListGrid.SelectedItem;

            if (!isSelected(i))
            {
                MessageBox.Show("Niste izabrali operaciju koju želita da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete datu operaciju?", "Brisanje operacije", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        appointmentService.DeleteAppointment(appointment);
                        OperationList ol = new OperationList();
                        this.NavigationService.Navigate(ol);
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }
    }
}
