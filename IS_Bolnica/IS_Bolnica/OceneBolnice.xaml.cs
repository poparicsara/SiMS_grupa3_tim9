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
        public OceneBolnice()
        {
            InitializeComponent();

            EvaluationRepository exStorage = new EvaluationRepository();
            List<Evaluation> ocene = exStorage.loadFromFile("Ocene.json");
            ObservableCollection<Evaluation> oceneUlogovanogPacijenta = new ObservableCollection<Evaluation>();

            foreach (Evaluation ocena in ocene)
            {
                if (ocena.Patient.Username.Equals(PatientWindow.username_patient) && !ocena.Bolnica.Equals(""))
                    oceneUlogovanogPacijenta.Add(ocena);
            }

            OceneBolniceDataBinding.ItemsSource = oceneUlogovanogPacijenta;
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}