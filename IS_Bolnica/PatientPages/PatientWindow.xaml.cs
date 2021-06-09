using Model;
using IS_Bolnica.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_Bolnica.GUI.Patient.View;
using IS_Bolnica.Model;
using IS_Bolnica.PatientPages;

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        public static String username_patient { get; set; }
        public static Patient loggedPatient { get; set; }
        private FindAttributesService findAttributesService = new FindAttributesService();
        private PrescriptionService prescriptionService = new PrescriptionService();
        private NotificationService notificationService = new NotificationService();
        public static Frame MyFrame { get; set; }
        public PatientWindow(String username)
        {
            InitializeComponent();

            loggedPatient = findAttributesService.findPatientByUsername(username);
            username_patient = username;
            MyFrame = StartFrame;

            MyFrame.NavigationService.Navigate(new StartPage());
           
            threadForNotificationsAboutTherapy();
        }

        private void threadForNotificationsAboutTherapy()
        {
            Thread reminderThread = new Thread(new ThreadStart(methodForNotificationsAboutTherapy));
            reminderThread.Start();
        }
        private void methodForNotificationsAboutTherapy()
        {
            while (true)
            {
                List<Prescription> patientPrescriptions = prescriptionService.getPatientPrescriptions(username_patient);

                foreach (Prescription prescription in patientPrescriptions)
                {
                    if (prescription.Therapy.Dose == 1)
                    {
                        if (notificationService.notificationByOneDose(prescription) == 1)
                            MessageBox.Show("U 15:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");

                    }
                    else if (prescription.Therapy.Dose == 2)
                    {
                        if (notificationService.notificationByTwoDose(prescription) == 1) 
                            MessageBox.Show("U 08:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");
                        else if (notificationService.notificationByTwoDose(prescription) == 2)
                            MessageBox.Show("U 20:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");
                    }
                    else if (prescription.Therapy.Dose == 3)
                    {
                        if (notificationService.notificationByThreeDose(prescription) == 1)
                            MessageBox.Show("U 07:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");
                        else if (notificationService.notificationByThreeDose(prescription) == 2)
                            MessageBox.Show("U 15:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");
                        else if (notificationService.notificationByThreeDose(prescription) == 3)
                            MessageBox.Show("U 23:00 treba da popijete lek: " + prescription.Therapy.MedicationName, "PODSETNIK!");
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        private void AppointmentsButtonClicked(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void HelpButtonClicked(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Tutorial());
        }

        private void LogoutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            MyFrame.NavigationService.Navigate(new Profile());
        }
    }
}