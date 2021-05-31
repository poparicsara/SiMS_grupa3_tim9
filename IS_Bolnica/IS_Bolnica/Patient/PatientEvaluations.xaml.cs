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

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for OcenePacijenta.xaml
    /// </summary>
    public partial class PatientEvaluations : Window
    {
        public PatientEvaluations()
        {
            InitializeComponent();
        }

        private void ButtonOcenePregledaClicked(object sender, RoutedEventArgs e)
        {
            EvaluationsForAppointments ocenePregleda = new EvaluationsForAppointments();
            ocenePregleda.Show();
        }

        private void ButtonOceneBolniceClicked(object sender, RoutedEventArgs e)
        {
            EvaluationsForHospital oceneBolnice = new EvaluationsForHospital();
            oceneBolnice.Show();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}