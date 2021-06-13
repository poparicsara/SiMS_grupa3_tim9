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
using System.Windows.Navigation;
using System.Windows.Shapes;
using IS_Bolnica.Open_Closed_Principle;
using Model;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Page
    {
        private ISuggestionService iSuggestionService;

        public Suggestions(ISuggestionService chosenSuggestion)
        {
            InitializeComponent();
            iSuggestionService = chosenSuggestion;
            callSuggestionService();
        }

        public void callSuggestionService()
        {
            SuggestionsDataBinding.ItemsSource = iSuggestionService.getSuggestions();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new AddNewAppointment());
        }
    }
}
