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

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for OcenjivanjeBolnice.xaml
    /// </summary>
    public partial class OcenjivanjeBolnice : Window
    {
        public OcenjivanjeBolnice()
        {
            InitializeComponent();
            BolnicaTextBox.Text = "Zdravo bolnica, Novi Sad";
        }

        private void ButtonZabeleziClicked(object sender, RoutedEventArgs e)
        {
            EvaluationFileStorage exStorage = new EvaluationFileStorage();
            List<Evaluation> ocene = exStorage.loadFromFile("Ocene.json");
            Evaluation ocena = new Evaluation();
            ocena.Bolnica = "Zdravo bolnica, Novi Sad";
            Patient patient = new Patient();
            patient.Username = PatientWindow.username_patient;

            ocena.Patient = patient;
            ocena.Assessment = Convert.ToInt32(OcenaComboBox.Text);
            ocena.Comment = CommentTextBox.Text;

            ocene.Add(ocena);
            this.Close();
            exStorage.saveToFile(ocene, "Ocene.json");
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
