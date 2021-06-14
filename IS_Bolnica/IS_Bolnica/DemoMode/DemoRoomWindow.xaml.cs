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
        private Room selectedRoom;
        private RoomService service = new RoomService();

        public DemoRoomWindow()
        {

            InitializeComponent();

            roomDataGrid.ItemsSource = service.GetRooms();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddRoomDemo newRoom = new AddRoomDemo();
            newRoom.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyRoomSelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu prostoriju?",
                    "Brisanje prostorije", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void SetSelectedRoom()
        {
            selectedRoom = (Room)roomDataGrid.SelectedItem;
        }

        private bool IsAnyRoomSelected()
        {
            if (roomDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijednu prostoriju!");
                return false;
            }
            else
            {
                SetSelectedRoom();
                return true;
            }
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyRoomSelected())
            {
                EditRoomDemo ew = new EditRoomDemo(selectedRoom);
                ew.Show();
                this.Close();
            }
        }


        private void searchKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = service.GetSearchedRooms(searchBox.Text.ToLower());
            roomDataGrid.ItemsSource = filtered;
        }

        private void NotificationButtonClicked(object sender, RoutedEventArgs e)
        {

        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoMedicamentWindow mw = new DemoMedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void RenovationButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyRoomSelected())
            {
                RenovationDemo rw = new RenovationDemo();
                rw.Show();
                this.Close();
            }
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoInventoryWindow inventarWindow = new DemoInventoryWindow();
            inventarWindow.Show();
            this.Close();
        }

        private void MergeButtonClicked(object sender, RoutedEventArgs e)
        {
            MergeDemo mw = new MergeDemo();
            mw.Show();
            this.Close();
        }

        private void SeparateButtonClicked(object sender, RoutedEventArgs e)
        {
            SeparateDemo sw = new SeparateDemo();
            sw.Show();
            this.Close();
        }

        private void SignOutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

