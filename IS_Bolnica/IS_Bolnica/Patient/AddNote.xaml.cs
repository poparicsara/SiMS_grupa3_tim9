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
    /// Interaction logic for AddNote.xaml
    /// </summary>
    public partial class AddNote : Window
    {
        private EvaluationService evaluationService = new EvaluationService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public AddNote()
        {
            InitializeComponent();
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
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
            this.Close();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            Beleske notes = new Beleske();
            notes.Show();
            this.Close();
        }
    }
}
