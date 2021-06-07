using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class Report : Page
    {
        private Page previousPage;
        private ReportData reportData;
        private ReportService reportService = new ReportService();

        public Report(Page previousPage, ReportData reportData)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.reportData = reportData;
            this.DataContext = this;

            RoomReport.ItemsSource = reportService.GetAppointmentsForReport(reportData);

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void PrintButton_Clicked(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(report, "Report");
                }
            }
            finally
            {
                this.IsEnabled = true;
            }
        }
    }
}
