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
using Model;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for Suggestions.xaml
    /// </summary>
    public partial class Suggestions : Page
    {
        private SuggestionServiceBySelectedDoctor suggestionServiceBySelectedDoctor = new SuggestionServiceBySelectedDoctor();
        private SuggestionServiceWithoutSelection suggestionServiceWithoutSelection = new SuggestionServiceWithoutSelection();
        private SuggestionServiceBySelectedDate suggestionServiceBySelectedDate = new SuggestionServiceBySelectedDate();
        private SuggestionServiceBySelectedDateAndDoctor suggestionServiceBySelectedDateAndDoctor = new SuggestionServiceBySelectedDateAndDoctor();

        public static Doctor selectedDoctor = new Doctor();
        public static DateTime selectedDate = new DateTime();
        private DoctorService doctorService = new DoctorService();
        private FindAttributesService findAttributesService = new FindAttributesService();

        public Suggestions(String doctor, String date)
        {
            InitializeComponent();
            if (!doctor.Equals("") && date.Equals(""))
            {
                selectedDoctor = doctorService.FindDoctorByName(doctor.Split('(')[0]);

                SuggestionsDataBinding.ItemsSource = suggestionServiceBySelectedDoctor.getSuggestions();
            }
            else if (!date.Equals("") && doctor.Equals(""))
            {
                selectedDate = findAttributesService.returnDateBySelectionInDatePicker(date);
                SuggestionsDataBinding.ItemsSource = suggestionServiceBySelectedDate.getSuggestions();
            }
            else if (!date.Equals("") && !doctor.Equals(""))
            {
                selectedDoctor = doctorService.FindDoctorByName(doctor.Split('(')[0]);
                selectedDate = findAttributesService.returnDateBySelectionInDatePicker(date);
                SuggestionsDataBinding.ItemsSource = suggestionServiceBySelectedDateAndDoctor.getSuggestions();
            }
            else
                SuggestionsDataBinding.ItemsSource = suggestionServiceWithoutSelection.getSuggestions();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new AddNewAppointment());
        }
    }
}
