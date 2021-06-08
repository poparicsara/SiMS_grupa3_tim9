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
    /// Interaction logic for ChoosePeriodForReportPage.xaml
    /// </summary>
    public partial class ChoosePeriodForReportPage : Page
    {
        private ReportService reportService = new ReportService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        public ChoosePeriodForReportPage()
        {
            InitializeComponent();
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new CalendarForAppointments());
        }

        private void ButtonSendClicked(object sender, RoutedEventArgs e)
        {
            if (findAttributesService.checkDatePicker(StartDatePicker.Text) && findAttributesService.checkDatePicker(EndDatePicker.Text))
            {
                if (reportService.getMonth(StartDatePicker.Text) == reportService.getMonth(EndDatePicker.Text))
                {
                    if (reportService.getDay(StartDatePicker.Text) < reportService.getDay(EndDatePicker.Text))
                        PatientWindow.MyFrame.NavigationService.Navigate(new TheReportPage(StartDatePicker.Text, EndDatePicker.Text));
                    else
                        PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("Greška", "Period između startnog i krajnjeg datuma ne postoji!"));
                }
                else
                {
                    PatientWindow.MyFrame.NavigationService.Navigate(new TheReportPage(StartDatePicker.Text, EndDatePicker.Text));
                }
            } else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Nisu popunjena sva neophodna polja!"));
        }

        private void ButtonStopClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new CalendarForAppointments());
        }
    }
}
