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
using Model;

namespace IS_Bolnica.DemoMode
{

    public partial class MergeDemo : Window
    {
        private RoomService roomService = new RoomService();

        public MergeDemo()
        {
            InitializeComponent();

            room1Box.ItemsSource = roomService.GetRoomNumbers();
            room2Box.ItemsSource = roomService.GetRoomNumbers();

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

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, EventArgs e)
        {
            global::Model.Director director = new global::Model.Director();
            DemoRoomWindow rw = new DemoRoomWindow();
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

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
