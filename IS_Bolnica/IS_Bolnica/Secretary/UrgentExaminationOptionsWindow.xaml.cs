using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Windows;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class UrgentExaminationOptionsWindow : Window
    {
        private Specialization specialization = new Specialization();
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();
        private List<Appointment> appointments = new List<Appointment>();
        private UrgentAppointmentService urgentAppointmentService = new UrgentAppointmentService();

        public UrgentExaminationOptionsWindow(Appointment appointment, Specialization specialization)
        {
            InitializeComponent();
            this.appointment = appointment;
            this.specialization = specialization;

            AppointmentOptions.ItemsSource = urgentAppointmentService.GetUrgentExaminationOptions(appointment, specialization);
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
        }

        private void addUrgentExamination(object sender, RoutedEventArgs e)
        {
            int i = AppointmentOptions.SelectedIndex; 
            Appointment selectedAppointment = new Appointment();
            selectedAppointment = (Appointment)AppointmentOptions.SelectedItem;
            appointments = appointmentService.GetAppointments();

            if(i == -1)
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

