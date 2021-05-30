using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class OperationListWindow : Window, INotifyPropertyChanged
    {
        private OperationsFileStorage operationsFileStorage = new OperationsFileStorage();
        private Operation operation = new Operation();

        private Appointment appointment = new Appointment();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Appointment> operations = new List<Appointment>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private AppointmentService appointmentService = new AppointmentService();

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public OperationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            OperationList.ItemsSource = appointmentService.GetOperations();

        }

        private void addOperation(object sender, RoutedEventArgs e)
        {
            Secretary.AddOperationWindow aow = new Secretary.AddOperationWindow();
            aow.Show();
            this.Close();
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

        private void editOperation(object sender, RoutedEventArgs e)
        {
            int i = OperationList.SelectedIndex;

            appointment = (Appointment) OperationList.SelectedItem;
            

            if(!isSelected(i))
            {
                MessageBox.Show("Niste izabrali operaciju koju želite da izmenite!");
            }
            else
            {
                Secretary.EditOperationWindow eow = new Secretary.EditOperationWindow(appointment);
                setElementsEOW(eow, appointment);

                eow.Show();
                this.Close();
            }
      
        }

        private void setElementsEOW(EditOperationWindow eow, Appointment appointment)
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

        private void deleteOperation(object sender, RoutedEventArgs e)
        {
            int i = OperationList.SelectedIndex;

            appointment = (Appointment) OperationList.SelectedItem;

            if(!isSelected(i))
            {
                MessageBox.Show("Niste izabrali operaciju koju želita da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete datu operaciju?", "Brisanje operacije", MessageBoxButton.YesNo);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        appointmentService.DeleteAppointment(appointment);
                        this.Close();
                        Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
                        olw.Show();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}
