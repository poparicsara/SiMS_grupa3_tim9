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

namespace IS_Bolnica
{
    public partial class EditWindow : Window
    {
        private int selectedRoom;

        public EditWindow(int room)
        {
            InitializeComponent();

                //all rooms
                RoomRecordFileStorage storage = new RoomRecordFileStorage();
                List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");

                roomBox.Text = rooms.ElementAt(room).Id;
                wardBox.Text = rooms.ElementAt(room).HospitalWard;

                RoomPurpose purpose = rooms.ElementAt(room).roomPurpose;
                purposeBox.Text = purpose.Name;

                selectedRoom = room;

                Director director = new Director();
                UpravnikWindow uw = new UpravnikWindow(director);
                uw.Close();
            
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            RoomRecord newRoom = new RoomRecord();
            newRoom.Id = roomBox.Text;
            newRoom.HospitalWard = wardBox.Text;

            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            newRoom.roomPurpose = purpose;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");
            rooms.ElementAt(selectedRoom).Id = newRoom.Id;
            rooms.ElementAt(selectedRoom).HospitalWard = newRoom.HospitalWard;
            rooms.ElementAt(selectedRoom).roomPurpose = newRoom.roomPurpose;
            storage.saveToFile(rooms, "Sobe.json");

            Director d = new Director();
            UpravnikWindow uw = new UpravnikWindow(d);
            uw.lvDataBinding.Items.Refresh();
            uw.Show();
            this.Close();
        }

        private void ShowInventoryClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Director d = new Director();
            UpravnikWindow uw = new UpravnikWindow(d);
            uw.lvDataBinding.Items.Refresh();
            uw.Show();
            this.Close();
        }
    }
}
