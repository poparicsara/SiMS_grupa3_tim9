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

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Page
    {
        private SuggestionService suggestionService = new SuggestionService();
        
        public Suggestions(String doctor, String date)
        {
            InitializeComponent();
            if (!doctor.Equals("") && date.Equals(""))
                PredloziBinding.ItemsSource = suggestionService.getSuggestionsBySelectedDoctor(doctor.Split('(')[0]);
            else if (!date.Equals("") && doctor.Equals(""))
                PredloziBinding.ItemsSource = suggestionService.getSuggestionsBySelectedDate(date);
            else if(!date.Equals("") && !doctor.Equals(""))
                PredloziBinding.ItemsSource = suggestionService.getSuggestionsBySelectedDateAndDoctor(doctor.Split('(')[0], date);
            else
                PredloziBinding.ItemsSource = suggestionService.getSuggestions();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new AddNewAppointment());
        }
    }
}
