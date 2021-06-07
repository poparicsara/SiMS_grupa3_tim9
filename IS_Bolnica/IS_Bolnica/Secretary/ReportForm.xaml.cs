using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class ReportForm : Page
    { 
        private Page previousPage;
        private FindAttributesService findAttributesService = new FindAttributesService();

        public ReportForm(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            this.DataContext = this;
            roomBox.ItemsSource = findAttributesService.GetAllRoomIds();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void createReport(object sender, RoutedEventArgs e)
        {
            int roomId =(int) roomBox.SelectedItem;
            DateTime dateFrom = (DateTime) dateBoxFrom.SelectedDate;
            DateTime dateTo = (DateTime) dateBoxTo.SelectedDate;

            ReportData reportData = new ReportData(roomId, dateFrom, dateTo);
            Report r = new Report(this, reportData);
            this.NavigationService.Navigate(r);
        }
    }
}
