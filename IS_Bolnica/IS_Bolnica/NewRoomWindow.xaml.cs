using IS_Bolnica.Model;
using Model;
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

namespace IS_Bolnica
{
    public partial class NewRoomWindow : Window
    {
        public NewRoomWindow()
        {
            InitializeComponent();

            /*HospitalWardFileStorage storage = new HospitalWardFileStorage();
            List<HospitalWard> wards = storage.GetAll();
            wardComboBox.ItemsSource = wards;*/

        }

        private void DoneAddingButton(object sender, RoutedEventArgs e)
        {
            RoomRecord newRoom = new RoomRecord();
            newRoom.Id = roomBox.Text;
            newRoom.HospitalWard = wardBox.Text;
            //HospitalWard ward = wardComboBox.SelectedItem;

            RoomPurpose purpose = new RoomPurpose { Name = purposeBox.Text };
            newRoom.roomPurpose = purpose;

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = storage.loadFromFile("Sobe.json");
            rooms.Add(newRoom);
            storage.saveToFile(rooms, "Sobe.json");

            Director d = new Director();
            UpravnikWindow uw = new UpravnikWindow(d);

            uw.Show();
            this.Close();
        }

        private void ShowInventory(object sender, RoutedEventArgs e)
        {
            InventoryWindow iw = new InventoryWindow();
            iw.Show();
            //this.Close();
        }
    }
}
