using IS_Bolnica.Model;
using IS_Bolnica.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for ShowAnamneses.xaml
    /// </summary>
    public partial class ShowAnamneses : Page
    {
        private AnamnesisService anamnesisService = new AnamnesisService();
        public ShowAnamneses()
        {
            InitializeComponent();
            HealthCardItemsDataBinding.ItemsSource = anamnesisService.getPatientAnamneses(PatientWindow.username_patient);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new MyAppointments());
        }

        private void NotesButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new Notes());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Anamnesis> patientAnamneses = anamnesisService.getPatientAnamneses(PatientWindow.username_patient);
            var filtered = patientAnamneses.Where(anamnesis => anamnesis.Diagnosis.ToLower().Contains(SearchBox.Text.ToLower()));
            HealthCardItemsDataBinding.ItemsSource = filtered;
        }
    }
}
