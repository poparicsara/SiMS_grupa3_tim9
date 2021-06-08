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

    public partial class AddRoomDemo : Window
    {
        private RoomService service = new RoomService();

        public AddRoomDemo()
        {
            InitializeComponent();

            wardBox.ItemsSource = service.GetHospitalWards();
            wardBox.SelectedItem = service.GetHospitalWards().ElementAt(0);

            purposeBox.ItemsSource = service.GetRoomPurposes();
            purposeBox.SelectedItem = service.GetRoomPurposes().ElementAt(0);

            roomBox.Focusable = true;
            roomBox.Focus();

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


        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DemoRoomWindow rw = new DemoRoomWindow();
            rw.Show();
        }
    }
}
