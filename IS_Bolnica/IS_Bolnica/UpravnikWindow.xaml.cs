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
        public UpravnikWindow(Director director)
        {
            InitializeComponent();

            DataContext = director;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");
            //List<RoomRecord> rooms = new List<RoomRecord>();

            lvDataBinding.ItemsSource = rooms;

            /*rooms = new List<RoomRecord>();
            var purpose1 = new RoomPurpose { Name = "Soba" };
            var room1 = new RoomRecord { Id = "101", HospitalWard = "Neurologija", roomPurpose = purpose1 };
            var purpose2 = new RoomPurpose { Name = "Ordinacija" };
            var room2 = new RoomRecord { Id = "102", HospitalWard = "Ortopedija", roomPurpose = purpose2 };
            var purpose3 = new RoomPurpose { Name = "Operaciona sala" };
            var room3 = new RoomRecord { Id = "103", HospitalWard = "Psihijatrija", roomPurpose = purpose3 };

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

            director.DeleteRoom(room);

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            lvDataBinding.ItemsSource = storage.loadFromFile("Sobe.json");

        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            int room = lvDataBinding.SelectedIndex;
            EditWindow ew = new EditWindow(room);
            ew.Show();
            this.Close();
        }

        public void refreshData()
        {
            lvDataBinding.Items.Refresh();
        }
    }
        
 }

    

