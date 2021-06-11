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
    /// Interaction logic for Notes.xaml
    /// </summary>
    public partial class Notes : Page
    {
        private EvaluationService evaluationService = new EvaluationService();
        public Notes()
        {
            InitializeComponent();
            NotesDataBinding.ItemsSource = evaluationService.getPatientNotes();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new ShowAnamneses());
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new AddNewNote());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Evaluation> patientNotes = evaluationService.getPatientNotes();
            var filtered = patientNotes.Where(note => note.Comment.ToLower().Contains(SearchBox.Text.ToLower()));
            NotesDataBinding.ItemsSource = filtered;
        }
    }
}
