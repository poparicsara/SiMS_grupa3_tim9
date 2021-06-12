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
using System.Windows.Resources;
using System.Windows.Shapes;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica
{
    public partial class SeparateRoomWindow : Window
    {
        private string selectedStartDate;
        private string selectedEndDate;
        private int selectedHour;
        private int selectedMinute;
        private RenovationService renovationService = new RenovationService();
        private int newRoomNumber;
        private Room room1;
        private RoomService roomService = new RoomService();

        public SeparateRoomWindow()
        {
            InitializeComponent();

            room1Box.ItemsSource = roomService.GetRoomNumbers();

            startDate.Focusable = true;
            startDate.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
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

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsSomethingNull())
            {
                MessageBox.Show("Sva polja moraju biti popunjena!");
            }
            else if (SetRooms())
            {
                CheckRoomNumber();
            }

        }

        private bool IsSomethingNull()
        {
            return startDate.SelectedDate == null || endDate.SelectedDate == null || room1Box.SelectedItem == null || 
                   hourBox.SelectedItem == null || minuteBox.SelectedItem == null || roomNumberBox.Text.Equals("");
        }

        private bool CheckEndDate()
        {
            string fullDate = selectedEndDate + " " + selectedHour + ":" + selectedMinute;
            DateTime fullDateOfChange = Convert.ToDateTime(fullDate);
            if (endDate.SelectedDate < startDate.SelectedDate || fullDateOfChange <= DateTime.Now)
            {
                MessageBox.Show("Datum kraja renoviranja mora biti nakon datuma početka renoviranja!");
                return false;
            }
            return true;
        }

        private void CheckRoomNumber()
        {
            if (roomService.IsRoomNumberUnique(newRoomNumber))
            {
                renovationService.SeparateRoom(room1, selectedStartDate, selectedEndDate, selectedHour, selectedMinute, newRoomNumber);
                /*Room room2 = new Room
                    {HospitalWard = room1.HospitalWard, Id = newRoomNumber, RoomPurpose = room1.RoomPurpose};
                roomService.AddRoom(room2);*/
                this.Close();
            }
            else
            {
                MessageBox.Show("Vec postoji soba sa izabranim brojem!");
            }
        }

        private bool SetRooms()
        {
            room1 = roomService.GetRoom((int)room1Box.SelectedItem);
            newRoomNumber = (int)Int64.Parse(roomNumberBox.Text);
            return CheckEndDate();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Director director = new Director();
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
        }

        private void RoomSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string roomNumber = combo.SelectedItem.ToString();
            Room room = roomService.GetRoom((int)Int64.Parse(roomNumber));
            roomBlock.Text = room.HospitalWard + "-" + room.RoomPurpose.Name;
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
    }
}
