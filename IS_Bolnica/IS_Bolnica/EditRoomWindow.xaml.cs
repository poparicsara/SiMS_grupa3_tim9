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
        private RoomRecord newRoom = new RoomRecord();
        private RoomRecord oldRoom = new RoomRecord();
        private Director director = new Director();
        private List<string> hospitalWards = new List<string>();
        private Specialization specialization = new Specialization();
        private List<string> purposes = new List<string>();
        private RoomService service = new RoomService();

        public EditRoomWindow(RoomRecord room)
        {
            InitializeComponent();

            oldRoom = room;

            wardBox.ItemsSource = GetHospitalWards();
            SetInitWard();

            purposeBox.ItemsSource = GetRoomPurposes();
            SetInitPurpose();

            idBox.Text = oldRoom.Id.ToString();
        }

        private List<string> GetHospitalWards()
        {
            List<Specialization> specializations = specialization.getSpecializations();
            foreach (Specialization s in specializations)
            {
                hospitalWards.Add(s.Name);
            }
            return hospitalWards;
        }

        private List<string> GetRoomPurposes()
        {
            RoomPurpose purpose = new RoomPurpose();
            purposes = purpose.GetPurposes();
            return purposes;
        }

        private void SetInitWard()
        {
            foreach(string s in hospitalWards)
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
            foreach (string s in purposes)
            {
                if (s.Equals(oldRoom.roomPurpose.Name))
                {
                    purposeBox.SelectedItem = s;
                    break;
                }
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetNewRoom();
            //Save();
            service.EditRoom(oldRoom, newRoom);
            this.Close();
        }

        private void SetNewRoom()
        {
            newRoom.Id = (int)Int64.Parse(idBox.Text);
            newRoom.HospitalWard = wardBox.Text;
            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            newRoom.roomPurpose = purpose;
        }

        private void Save()
        {
            RoomRepository storage = new RoomRepository();
            storage.EditRoom(oldRoom, newRoom);
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
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
        }
    }
}
