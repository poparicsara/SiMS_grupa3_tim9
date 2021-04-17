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

        public EditWindow(RoomRecord room)
        {
            InitializeComponent();

            List<string> hospitalWard = new List<string>();
            hospitalWard.Add("Pedijatrija");
            hospitalWard.Add("Ortopedija");
            hospitalWard.Add("Ginekologija");
            hospitalWard.Add("Urologija");

            wardBox.ItemsSource = hospitalWard;

            List<string> roomPurpose = new List<string>();
            RoomPurpose purpose1 = new RoomPurpose { Name = "Ordinacija" };
            RoomPurpose purpose2 = new RoomPurpose { Name = "Operaciona sala" };
            RoomPurpose purpose3 = new RoomPurpose { Name = "Soba" };
            roomPurpose.Add(purpose1.Name);
            roomPurpose.Add(purpose2.Name);
            roomPurpose.Add(purpose3.Name);

            purposeBox.ItemsSource = roomPurpose;

            oldRoom = room;

            roomBox.Text = oldRoom.Id.ToString();
            wardBox.SelectedItem = oldRoom.HospitalWard;
            purposeBox.SelectedItem = oldRoom.roomPurpose.Name;
        }

       

            private void DoneButton(object sender, RoutedEventArgs e)
        {
            editRoom.Id = (int)Int64.Parse(roomBox.Text);
            editRoom.HospitalWard = wardBox.Text;
            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            editRoom.roomPurpose = purpose;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            storage.EditRoom(oldRoom, editRoom);
            
            this.Close();
        }

        private void ShowInventoryClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow(oldRoom);
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
