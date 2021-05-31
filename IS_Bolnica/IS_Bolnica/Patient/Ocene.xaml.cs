using IS_Bolnica.Model;
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
    /// Interaction logic for Ocene.xaml
    /// </summary>
    public partial class Ocene : Window
    {
        private EvaluationService evaluationService = new EvaluationService();
        public Ocene()
        {
            InitializeComponent();

            OceneDataBinding.ItemsSource = evaluationService.getPatientEvaluationsOfAppointment();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
