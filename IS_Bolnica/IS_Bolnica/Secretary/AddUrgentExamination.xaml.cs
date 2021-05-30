using Model;
using System;
using System.Collections.Generic;
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
    public partial class AddUrgentExamination : Window
    {
        private Specialization specialization = new Specialization();
        private Patient patient = new Patient();
        private GuestUser guestUser = new GuestUser();
        private Appointment appointment = new Appointment();

        private FindAttributesService findAttributesService = new FindAttributesService();

        public AddUrgentExamination()
        {
            InitializeComponent();
            specializationBox.ItemsSource = findAttributesService.GetSpecializationNames();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount(sender);
            gua.Show();
            this.Close();
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if (patientIdBox.Text != "")
            {
                patient = findAttributesService.FindPatient(patientIdBox.Text);
            }
            else if (patientIdBox.Text == "" && patientIdBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli id pacijenta");
                return;
            }
            else if (systemNameBox.Text != "")
            {
                guestUser = findAttributesService.FindGuest(systemNameBox.Text);
            }
            else if (systemNameBox.Text == "" && systemNameBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli sistemsko ime guest korisnika");
                return;
            }

            appointment = new Appointment {GuestUser = guestUser, Patient = patient};
            specialization = findAttributesService.FindSpecialization(specializationBox.SelectedItem.ToString());

            UrgentExaminationOptionsWindow uoow = new UrgentExaminationOptionsWindow(appointment, specialization);
            uoow.Show();
            this.Close();
        }

        private void existableRButton_Checked(object sender, RoutedEventArgs e)
        {
            systemNameBox.IsEnabled = false;
            patientIdBox.IsEnabled = true;
        }

        private void guestRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = false;
            systemNameBox.IsEnabled = true;
        }
    }
}
