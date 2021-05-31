using Model;
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
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class DirectorProfileWindow : Window
    {
        private ChangeInventoryPlaceService service = new ChangeInventoryPlaceService();

        public DirectorProfileWindow()
        {
            InitializeComponent();

            service.CheckUnexecutedShiftings();
            RenovationService renovationService = new RenovationService();
            renovationService.CheckUnexecutedMergings();
            renovationService.CheckUnexecutedSeparations();

        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            Director d = new Director();
            RoomWindow uw = new RoomWindow(d);
            uw.Show();
            this.Close();
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow uw = new InventoryWindow();
            uw.Show();
            this.Close();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void LogOutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            EditDirectorProfileWindow editWindow = new EditDirectorProfileWindow();
            editWindow.Show();
            this.Close();
        }
    }
}
