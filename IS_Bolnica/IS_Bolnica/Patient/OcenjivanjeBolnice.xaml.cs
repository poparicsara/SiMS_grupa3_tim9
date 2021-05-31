using IS_Bolnica.Services;
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
        private FindAttributesService findAttributesService = new FindAttributesService();
        private EvaluationService evaluationService = new EvaluationService();
        public OcenjivanjeBolnice()
        {
            InitializeComponent();
            BolnicaTextBox.Text = "Zdravo bolnica, Novi Sad";
        }

        private void ButtonZabeleziClicked(object sender, RoutedEventArgs e)
        {
            Evaluation evaluation = new Evaluation();
            evaluation.Bolnica = "Zdravo bolnica, Novi Sad";
            evaluation.Patient = findAttributesService.findPatientByUsername(PatientWindow.username_patient);
            evaluation.Assessment = Convert.ToInt32(OcenaComboBox.Text);
            evaluation.Comment = CommentTextBox.Text;
            evaluation.numOfMinutes = 5;
            evaluation.commentType = 1;
            evaluationService.addNote(evaluation);
            this.Close();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}