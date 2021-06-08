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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for AddNewNote.xaml
    /// </summary>
    public partial class AddNewNote : Page
    {
        private EvaluationService evaluationService = new EvaluationService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public AddNewNote()
        {
            InitializeComponent();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new Notes());
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            if (evaluationService.checkNote(NoteTextBox.Text))
            {
                Evaluation evaluation = new Evaluation();
                evaluation.Patient = findAttributesService.findPatientByUsername(PatientWindow.username_patient);
                evaluation.Comment = NoteTextBox.Text;
                evaluation.commentType = 2;
                if (!minBox.Text.Equals(""))
                    evaluation.numOfMinutes = Convert.ToInt32(minBox.Text);
                else
                    evaluation.numOfMinutes = 5;
                evaluationService.addNote(evaluation);
                PatientWindow.MyFrame.NavigationService.Navigate(new Notes());
            } else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Niste uneli belešku!"));
        }
    }
}
