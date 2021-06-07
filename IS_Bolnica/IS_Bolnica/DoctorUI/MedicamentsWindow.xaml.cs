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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class MedicamentsWindow : Window
    {
        private UserService userService = new UserService();
        private MedicamentService medicamentService = new MedicamentService();
        public MedicamentsWindow()
        {
            InitializeComponent();
            medsDataGrid.ItemsSource = medicamentService.ShowApprovedMedicaments();
        }

        private void MedicationDoubleClicked(object sender, MouseButtonEventArgs e)
        {
            Medicament selectedMedicament = (Medicament) medsDataGrid.SelectedItem;
            UpdateMedicamentWindow updateMedicament = new UpdateMedicamentWindow(selectedMedicament);
            updateMedicament.Show();
            this.Close();
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
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

        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            userService.LogOut();
            this.Close();
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            this.Show();
        }
    }
}
