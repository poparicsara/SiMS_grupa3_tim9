using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
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

            idBox.Focusable = true;
            idBox.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);

        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (idBox.Text.Equals(""))
            {
                MessageBox.Show("Polje sa brojem sobe je obavezno!");
            }
            else
            {
                SetNewRoom();
                EditRoom();
            }
        }

        private void EditRoom()
        {
            if (service.IsRoomNumberUnique(newRoom.Id))
            {
                service.EditRoom(oldRoom, newRoom);
                this.Close();
            }
            else
            {
                MessageBox.Show("Već postoji postoji prostorija sa izabranim brojem");
            }
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

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RoomWindow rw = new RoomWindow();
            rw.Show();
        }
    }
}
