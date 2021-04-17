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
    public partial class Diagnosis : Window
    {
        public Diagnosis()
        {
            InitializeComponent();
        }

        private void izdajRecept(object sender, RoutedEventArgs e)
        {
            CreatePrescription createPrescription = new CreatePrescription();
            createPrescription.patientNameTxt.Text = patientNameTxt.Text;
            createPrescription.patientSurnameTxt.Text = patientSurnameTxt.Text;
            createPrescription.Show();
        }
    }
}
