using IS_Bolnica.Services;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OceneBolnice.xaml
    /// </summary>
    public partial class OceneBolnice : Window
    {
        private EvaluationService evaluationService = new EvaluationService();
        public OceneBolnice()
        {
            InitializeComponent();


            OceneBolniceDataBinding.ItemsSource = evaluationService.getPatientEvaluationsOfHospital();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}