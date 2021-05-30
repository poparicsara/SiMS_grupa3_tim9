using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using IS_Bolnica.Services;


namespace IS_Bolnica
{
    public partial class EditRoomWindow : Window
    {
        private Room newRoom = new Room();
        private Room oldRoom = new Room();
        private RoomService service = new RoomService();

        public EditRoomWindow(Room room)
        {
            InitializeComponent();

            oldRoom = room;

            wardBox.ItemsSource = service.GetHospitalWards();
            wardBox.SelectedItem = oldRoom.HospitalWard;

            purposeBox.ItemsSource = service.GetRoomPurposes();
            purposeBox.SelectedItem = oldRoom.RoomPurpose.Name;

            idBox.Text = oldRoom.Id.ToString();
        }

        private void SetInitWard()
        {
            foreach(string s in service.GetHospitalWards())
            {
                if (s.Equals(oldRoom.HospitalWard))
                {
                    wardBox.SelectedItem = s;
                    break;
                }
            }
        }

        private void SetInitPurpose()
        {
            foreach (string s in service.GetRoomPurposes())
            {
                if (s.Equals(oldRoom.RoomPurpose.Name))
                {
                    purposeBox.SelectedItem = s;
                    break;
                }
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewRoom();
            service.EditRoom(oldRoom, newRoom);
            this.Close();
        }

        private void SetNewRoom()
        {
            newRoom.Id = (int)Int64.Parse(idBox.Text);
            newRoom.HospitalWard = wardBox.Text;
            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            newRoom.RoomPurpose = purpose;
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            RoomInventory iw = new RoomInventory(oldRoom);
            iw.Show();
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Director director = new Director();
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
        }
    }
}
