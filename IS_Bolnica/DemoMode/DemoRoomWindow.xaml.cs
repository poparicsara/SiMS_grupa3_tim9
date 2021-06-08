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
using Model;

namespace IS_Bolnica.DemoMode
{

    public partial class DemoRoomWindow : Window
    {
        private RoomService service = new RoomService();
        public DemoRoomWindow()
        {
            InitializeComponent();

            roomDataGrid.ItemsSource = service.GetRooms();
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoInventoryWindow iw = new DemoInventoryWindow();
            iw.Show();
            this.Close();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoMedicamentWindow mw = new DemoMedicamentWindow();
            mw.Show();
            this.Close();
        }
    }
}
