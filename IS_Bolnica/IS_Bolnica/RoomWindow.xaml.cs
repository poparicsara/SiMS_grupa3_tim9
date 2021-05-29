using Model;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class RoomWindow : Window
    {
        private List<Room> rooms = new List<Room>();
        private Room selectedRoom;
        private RoomRepository storage = new RoomRepository();
        private RoomService service = new RoomService();

        public RoomWindow(Director director)
        {
            InitializeComponent();

            DataContext = director;

            roomDataGrid.ItemsSource = storage.GetRooms();
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            AddRoomWindow newRoom = new AddRoomWindow();
            newRoom.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyRoomSelected())
            {
                service.DeleteRoom(selectedRoom);
                RefreshRoomDataGrid();
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
                EditRoomWindow ew = new EditRoomWindow(selectedRoom);
                ew.Show();
                this.Close();
            }
        }

        public void RefreshRoomDataGrid()
        {
            roomDataGrid.ItemsSource = service.GetRooms();
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
            if (IsAnyRoomSelected())
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
            InventoryWindow inventarWindow = new InventoryWindow();
            inventarWindow.Show();
            this.Close();
        }

        private void MergeButtonClicked(object sender, RoutedEventArgs e)
        {
            MergeRoomsWindow mw = new MergeRoomsWindow();
            mw.Show();
            this.Close();
        }

        private void SeparateButtonClicked(object sender, RoutedEventArgs e)
        {
            SeparateRoomWindow sw = new SeparateRoomWindow();
            sw.Show();
            this.Close();
        }
    }

}



