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
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica
{
    public partial class MergeRoomsWindow : Window
    {
        private RoomService roomService = new RoomService();
        private int selectedHour;
        private int selectedMinute;
        private string selectedStartDate;
        private string selectedEndDate;
        private int newRoomNumber;
        private Room room1;
        private Room room2;
        private RenovationService renovationService = new RenovationService();

        public MergeRoomsWindow()
        {
            InitializeComponent();

            room1Box.ItemsSource = roomService.GetRoomNumbers();
            room2Box.ItemsSource = roomService.GetRoomNumbers();

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
            SetRooms();
            renovationService.MergeRooms(room1, room2, selectedStartDate, selectedEndDate, selectedHour, selectedMinute, newRoomNumber);
            this.Close();
        }

        private void SetRooms()
        {
            room1 = roomService.GetRoom((int) room1Box.SelectedItem);
            room2 = roomService.GetRoom((int) room2Box.SelectedItem);
            newRoomNumber = (int) Int64.Parse(roomNumberBox.Text);
        }

        private void SetStartDate(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as DatePicker;
            string fullDate = startDate.SelectedDate.ToString();
            string[] dateParts = fullDate.Split(' ');
            selectedStartDate = dateParts[0];
        }

        private void SetEndDate(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as DatePicker;
            string fullDate = endDate.SelectedDate.ToString();
            string[] dateParts = fullDate.Split(' ');
            selectedEndDate = dateParts[0];
        }

        private void SetHour(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string hour = (string)combo.SelectedItem.ToString();
            string[] temp = hour.Split(' ');
            int.TryParse(temp[1], out selectedHour);
        }

        private void SetMinute(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string minute = (string)combo.SelectedItem.ToString();
            string[] temp = minute.Split(' ');
            int.TryParse(temp[1], out selectedMinute);
        }

        private void ClosingWindow(object sender, EventArgs e)
        {
            Director director = new Director();
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
        }

        private void Room1SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string roomNumber = combo.SelectedItem.ToString();
            Room room = roomService.GetRoom((int)Int64.Parse(roomNumber));
            room1Block.Text = room.HospitalWard + "-" + room.RoomPurpose.Name;
        }

        private void Room2SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string roomNumber = combo.SelectedItem.ToString();
            Room room = roomService.GetRoom((int)Int64.Parse(roomNumber));
            room2Block.Text = room.HospitalWard + "-" + room.RoomPurpose.Name;
        }
    }
}
