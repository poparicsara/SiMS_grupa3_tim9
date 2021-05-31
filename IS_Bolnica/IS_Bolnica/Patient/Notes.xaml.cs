using IS_Bolnica.Services;
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
    /// Interaction logic for Beleske.xaml
    /// </summary>
    public partial class Notes : Window
    {
        private EvaluationService evaluationService = new EvaluationService(); 
        public Notes()
        {
            InitializeComponent();

            NotesDataBinding.ItemsSource = evaluationService.getPatientNotes();
        }
        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddNote addNote = new AddNote();
            addNote.Show();
            this.Close();
        }
    }


}
