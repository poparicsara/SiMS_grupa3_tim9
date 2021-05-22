using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace IS_Bolnica
{
    public partial class RoomWindow : Window
    {
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRecord selectedRoom;
        private RoomRecordFileStorage storage = new RoomRecordFileStorage();

        public RoomWindow(Director director)
        {
            InitializeComponent();

            DataContext = director;

            roomDataGrid.ItemsSource = storage.loadFromFile("Sobe.json");
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddRoomWindow newRoom = new AddRoomWindow();
            newRoom.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsSomeRoomSelected())
            {
                storage.DeleteRoom(selectedRoom);
                RefreshRoomDataGrid();
            }
        }

        private void SetSelectedRoom()
        {
            selectedRoom = (RoomRecord)roomDataGrid.SelectedItem;
        }

        private bool IsSomeRoomSelected()
        {
            if(roomDataGrid.SelectedIndex < 0)
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
            if (IsSomeRoomSelected())
            {
                EditRoomWindow ew = new EditRoomWindow(selectedRoom);
                ew.Show();
                this.Close();
            }
        }

        public void RefreshRoomDataGrid()
        {
            roomDataGrid.ItemsSource = storage.loadFromFile("Sobe.json");
        }

        private void searchKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = rooms.Where(room => room.roomPurpose.Name.StartsWith(searchBox.Text));
            roomDataGrid.ItemsSource = filtered;
        }

        private void NotificationButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorNotificationWindow dnw = new DirectorNotificationWindow();
            dnw.Show();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void RenovationButton(object sender, RoutedEventArgs e)
        {
            if (IsSomeRoomSelected())
            {
                RenovationWindow rWindow = new RenovationWindow(selectedRoom);
                rWindow.Show();
                this.Close();
            }
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow();
            profileWindow.Show();
            this.Close();
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            InventarWindow inventarWindow = new InventarWindow();
            inventarWindow.Show();
            this.Close();
        }
    }

}



