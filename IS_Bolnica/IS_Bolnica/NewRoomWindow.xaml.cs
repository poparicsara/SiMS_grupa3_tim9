using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class NewRoomWindow : Window
    {
        RoomRecord newRoom = new RoomRecord();
        Director director = new Director();
        string ward;
        string selectedPurpose;

        public NewRoomWindow()
        {
            InitializeComponent();

            List<string> hospitalWard = new List<string>();
            hospitalWard.Add("Pedijatrija");
            hospitalWard.Add("Ortopedija");
            hospitalWard.Add("Ginekologija");
            hospitalWard.Add("Urologija");

            wardBox.ItemsSource = hospitalWard;
            wardBox.SelectedItem = "Pedijatrija";

            List<string> roomPurpose = new List<string>();
            RoomPurpose purpose1 = new RoomPurpose { Name = "Ordinacija" };
            RoomPurpose purpose2 = new RoomPurpose { Name = "Operaciona sala" };
            RoomPurpose purpose3 = new RoomPurpose { Name = "Soba" };
            roomPurpose.Add(purpose1.Name);
            roomPurpose.Add(purpose2.Name);
            roomPurpose.Add(purpose3.Name);

            purposeBox.ItemsSource = roomPurpose;
            purposeBox.SelectedItem = "Ordinacija";
        }

        private void DoneAddingButton(object sender, RoutedEventArgs e)
        {
            newRoom.Id = (int)Int64.Parse(roomBox.Text);
            newRoom.HospitalWard = ward;
            RoomPurpose purpose = new RoomPurpose { Name = selectedPurpose };
            newRoom.roomPurpose = purpose;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            storage.AddRoom(newRoom);

            this.Close();
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

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            ward = (string)combo.SelectedItem;
        }

        private void PurposeSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedPurpose = (string)combo.SelectedItem;
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
