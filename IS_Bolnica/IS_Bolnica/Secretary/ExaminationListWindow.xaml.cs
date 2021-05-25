using Model;
using System;
using System.Collections.Generic;
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
    /// <summary>
    /// Interaction logic for ExaminationListWindow.xaml
    /// </summary>
    public partial class ExaminationListWindow : Window, INotifyPropertyChanged
    {
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();
        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public ExaminationListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            
            ExaminationList.ItemsSource = appointmentService.getExaminations();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {
            Secretary.AddExaminationWindow aew = new Secretary.AddExaminationWindow();
            aew.Show();
            this.Close();
        }

        private void editExamination(object sender, RoutedEventArgs e)
        {
            int i = ExaminationList.SelectedIndex;

            Appointment appointment = (Appointment) ExaminationList.SelectedItem;

            if(!isSelected(i))
            {
                MessageBox.Show("Niste izabrali pregled koji želite da izmenite!");
            }
            else
            {
                Secretary.EditExaminationWindow eew = new Secretary.EditExaminationWindow(appointment);
                setElementsEEW(eew, appointment);

                eew.Show();
                this.Close();

            }
        }

        private void setElementsEEW(EditExaminationWindow eew, Appointment appointment)
        {
            eew.idPatientBox.Text = appointment.Patient.Id;
            eew.hourBox.Text = appointment.StartTime.Hour.ToString();
            eew.minutesBox.Text = appointment.StartTime.Minute.ToString();
            eew.doctorBox.Text = appointment.Doctor.Name + " " + appointment.Doctor.Surname;
            eew.dateBox.SelectedDate = new DateTime(appointment.StartTime.Year, appointment.StartTime.Month, appointment.StartTime.Day);
            eew.durationInMinutesBox.Text = "30";
        }

        private bool isSelected(int i)
        {
            if(i == -1)
            {
                return false;
            } else
            {
                return true;
            }
        }

        private void deleteExamination(object sender, RoutedEventArgs e)
        {
            int i = ExaminationList.SelectedIndex;
            appointment = (Appointment) ExaminationList.SelectedItem;
            

            if(!isSelected(i))
            {
                MessageBox.Show("Niste izabrali pregled koji želite da obrišete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da izbrišete", "Brisanje pregleda", MessageBoxButton.YesNo);
                switch(result)
                {
                    case MessageBoxResult.Yes:
                        appointmentService.DeleteAppointment(appointment);
                        this.Close();
                        Secretary.ExaminationListWindow elw = new Secretary.ExaminationListWindow();
                        elw.Show();
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        
    }
}
