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
    public partial class UpravnikWindow : Window, INotifyPropertyChanged
    {
        private List<RoomRecord> rooms = new List<RoomRecord>();
        public UpravnikWindow(Director director)
        {
            InitializeComponent();

            DataContext = director;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            rooms = storage.loadFromFile("Sobe.json");
            //List<RoomRecord> rooms = new List<RoomRecord>();

            lvDataBinding.ItemsSource = rooms;

            /* rooms = new List<RoomRecord>();
             var purpose1 = new RoomPurpose { Name = "Soba" };
             var room1 = new RoomRecord { Id = "101", HospitalWard = "Neurologija", roomPurpose = purpose1 };
             var purpose2 = new RoomPurpose { Name = "Ordinacija" };
             var room2 = new RoomRecord { Id = "102", HospitalWard = "Ortopedija", roomPurpose = purpose2 };
             var purpose3 = new RoomPurpose { Name = "Operaciona sala" };
             var room3 = new RoomRecord { Id = "103", HospitalWard = "Psihijatrija", roomPurpose = purpose3 };



             List<Inventory> inventories = new List<Inventory>();

             var inventory1 = new Inventory { Id = 101, Name = "Špric", CurrentAmount = 20, Minimum = 2 };
             var inventory2 = new Inventory { Id = 202, Name = "Injekcija", CurrentAmount = 20, Minimum = 2 };
             var inventory3 = new Inventory { Id = 303, Name = "Štapić", CurrentAmount = 20, Minimum = 2 };

             inventories.Add(inventory1);
             inventories.Add(inventory2);
             inventories.Add(inventory3);

             room1.inventory = inventories;
             room2.inventory = inventories;
             room3.inventory = inventories;

             rooms.Add(room1);
             rooms.Add(room2);
             rooms.Add(room3);

             storage.saveToFile(rooms, "Sobe.json");*/

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            NewRoomWindow newRoom = new NewRoomWindow();
            newRoom.Show();
            this.Close();
        }

        private void DeleteButtonClicked(object sender, RoutedEventArgs e)
        {
            Director director = (Director)DataContext;
            int room = lvDataBinding.SelectedIndex;
            RoomRecord selectedRoom = (RoomRecord)lvDataBinding.SelectedItem;

            if (room < 0)
            {
                MessageBox.Show("Niste izabrali nijednu prostoriju!");
            }
            else
            {
                RoomRecordFileStorage storage = new RoomRecordFileStorage();
                storage.DeleteRoom(selectedRoom);
                lvDataBinding.ItemsSource = storage.loadFromFile("Sobe.json");
            }

        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            int index = lvDataBinding.SelectedIndex;
            RoomRecord selected = (RoomRecord)lvDataBinding.SelectedItem;

            if (index < 0)
            {
                MessageBox.Show("Niste izabrali nijednu prostoriju!");
            }
            else
            {
                EditWindow ew = new EditWindow(selected);
                ew.Show();
                this.Close();
            }

        }

        public void refreshData()
        {
            lvDataBinding.Items.Refresh();
        }

        private void searchKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = rooms.Where(room => room.roomPurpose.Name.StartsWith(searchBox.Text));

            lvDataBinding.ItemsSource = filtered;
        }

        private void InventarButtonClicked(object sender, RoutedEventArgs e)
        {
            InventarWindow iw = new InventarWindow();
            iw.Show();
            this.Close();
        }

        private void ObavestenjaButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorNotificationWindow dnw = new DirectorNotificationWindow();
            dnw.Show();
        }

        private void MedicamentButton(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();
        }
    }

}



