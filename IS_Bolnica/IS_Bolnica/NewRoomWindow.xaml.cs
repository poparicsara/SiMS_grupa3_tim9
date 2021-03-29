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
        RoomRecord newRoom = new RoomRecord();

        public NewRoomWindow()
        {
            InitializeComponent();

        }

        private void DoneAddingButton(object sender, RoutedEventArgs e)
        {
            RoomRecord newRoom = new RoomRecord();
            newRoom.Id = roomBox.Text;
            newRoom.HospitalWard = wardBox.Text;

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

        private void AddInventoryButton(object sender, RoutedEventArgs e)
        {
            NewInventory newi = new NewInventory();
            newi.Show();
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Director d = new Director();
            UpravnikWindow uw = new UpravnikWindow(d);
            uw.Show();
            this.Close();
        }
    }
}
