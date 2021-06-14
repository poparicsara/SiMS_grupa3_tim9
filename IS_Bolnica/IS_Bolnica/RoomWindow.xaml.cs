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
        private RoomService service = new RoomService();

        public RoomWindow(Director director)
        {
            InitializeComponent();

            DataContext = director;

            roomDataGrid.ItemsSource = service.GetRooms();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                    "Odjava", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
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
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da obrišete izabranu prostoriju?",
                    "Brisanje prostorije", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        service.DeleteRoom(selectedRoom);
                        RefreshRoomDataGrid();
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
            var filtered = service.GetSearchedRooms(searchBox.Text.ToLower());
            roomDataGrid.ItemsSource = filtered;
        }

        private void NotificationButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorNotificationWindow dnw = new DirectorNotificationWindow();
            dnw.Show();
            this.Close();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }

        private void RenovationButtonClicked(object sender, RoutedEventArgs e)
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

        private void SignOutButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjava", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ReportButtonClicked(object sender, RoutedEventArgs e)
        {
            ReportWindow rw = new ReportWindow();
            rw.Show();
            this.Close();
        }
    }

}



