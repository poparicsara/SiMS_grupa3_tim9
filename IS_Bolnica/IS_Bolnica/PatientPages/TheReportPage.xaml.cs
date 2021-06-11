using IS_Bolnica.Model;
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
    /// Interaction logic for TheReportPage.xaml
    /// </summary>
    public partial class TheReportPage : Page
    {
        private ReportService reportService = new ReportService();
        public TheReportPage(String startDate, String endDate)
        {
            InitializeComponent();

            ReportDataGrid.ItemsSource = reportService.getItemsForReport(startDate, endDate);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new ChoosePeriodForReportPage());
        }

        private void DownloadButtonClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(ReportForDownload, "Izveštaj");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
