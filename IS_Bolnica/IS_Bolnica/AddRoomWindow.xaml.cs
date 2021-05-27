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
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class AddRoomWindow : Window
    {
        Room newRoom = new Room();
        Director director = new Director();
        string selectedWard;
        string selectedPurpose;
        private List<Room> rooms = new List<Room>();
        private List<string> hospitalWards = new List<string>();
        private Specialization specialization = new Specialization();
        private RoomService service = new RoomService();

        public AddRoomWindow()
        {
            InitializeComponent();

            wardBox.ItemsSource = GetHospitalWards();
            wardBox.SelectedItem = GetHospitalWards().ElementAt(0);

            purposeBox.ItemsSource = GetRoomPurposes();
            purposeBox.SelectedItem = GetRoomPurposes().ElementAt(0);
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
            List<string> purposes = purpose.GetPurposes();
            return purposes;
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetRoomAttributes();
            service.AddRoom(newRoom);
            this.Close();
        }

        private void SetRoomAttributes()
        {
            newRoom.Id = (int)Int64.Parse(roomBox.Text);
            newRoom.HospitalWard = selectedWard;
            RoomPurpose purpose = new RoomPurpose { Name = selectedPurpose };
            newRoom.roomPurpose = purpose;
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

        private void SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWard = (string)combo.SelectedItem;
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
