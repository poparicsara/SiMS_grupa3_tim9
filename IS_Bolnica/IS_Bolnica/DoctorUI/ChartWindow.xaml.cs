using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.DoctorUI
{
    public partial class ChartWindow : Window
    {
        private UserService userService = new UserService();
        private AppointmentService appointmentService = new AppointmentService();
        private User loggedUser;
        public ChartWindow()
        {
            InitializeComponent();
            this.loggedUser = userService.GetLoggedUser();
            LoadPieChartData();
        }

        private void ExaminationButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();

        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void LoadPieChartData()
        {
            ((PieSeries) mcChart.Series[0]).ItemsSource = new KeyValuePair<string, int>[]
            {
                new KeyValuePair<string,int>("Pregledi  ", appointmentService.CountDoctorsExaminations()),
                new KeyValuePair<string,int>("Operacije  ", appointmentService.CountDoctorsOperations())
            };
        }
    }
}
