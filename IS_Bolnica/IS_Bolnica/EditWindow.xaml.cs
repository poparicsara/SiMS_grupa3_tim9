using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;


namespace IS_Bolnica
{
    public partial class EditWindow : Window
    {
        private int selectedRoom;
        private RoomRecord editRoom = new RoomRecord();
        private RoomRecord oldRoom = new RoomRecord();
        private Director director = new Director();

        public EditWindow(int room)
        {
            InitializeComponent();

           /* roomBox.Text = room.Id;
            wardBox.Text = room.HospitalWard;
            purposeBox.Text = room.roomPurpose.Name;

            oldRoom = room;

            selectedRoom = index;

            UpravnikWindow uw = new UpravnikWindow(director);
            uw.Close();*/

            //all rooms
             RoomRecordFileStorage storage = new RoomRecordFileStorage();
             List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");

             roomBox.Text = rooms.ElementAt(room).Id;
             wardBox.Text = rooms.ElementAt(room).HospitalWard;

             RoomPurpose purpose = rooms.ElementAt(room).roomPurpose;
             purposeBox.Text = purpose.Name;

             selectedRoom = room;

             UpravnikWindow uw = new UpravnikWindow(director);
             uw.Close(); 
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            editRoom.Id = roomBox.Text;
            editRoom.HospitalWard = wardBox.Text;
            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            editRoom.roomPurpose = purpose;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            storage.EditRoom(selectedRoom, editRoom);
            
            this.Close();
        }

        private void ShowInventoryClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            UpravnikWindow uw = new UpravnikWindow(director);
            uw.Show();
        }
    }
}
