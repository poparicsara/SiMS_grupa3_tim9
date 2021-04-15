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
    public partial class SelectedInventoryInRooms : Window
    {
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private List<InventoryInRoom> inRoomList = new List<InventoryInRoom>();
        private Inventory selected = new Inventory();

        public SelectedInventoryInRooms(Inventory selectedInventory)
        {
            InitializeComponent();

            selected = selectedInventory;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            
            //only for "Ordinacija"
            foreach (RoomRecord room in rooms)
            {
                InventoryInRoom inRoom = new InventoryInRoom();
                int exist = 0;
                int amount = 0;
                if (room.roomPurpose.Name == "Ordinacija")
                {
                    if(room.inventory == null)
                    {
                        break;
                    }
                    foreach(Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if(i.Id == selectedInventory.Id)
                        {
                            exist = 1;
                            amount = i.CurrentAmount;
                        }
                    }
                }
                if (exist == 1)
                {
                    inRoom.RoomNumber = room.Id;
                    inRoom.CurrentAmount = amount;
                    inRoomList.Add(inRoom);
                }
            }

            selectedInventoryData.ItemsSource = inRoomList;
        }

        private void ChangeButton(object sender, RoutedEventArgs e)
        {
            ChangeInventoryPlace cw = new ChangeInventoryPlace(selected);
            cw.Show();
            this.Close();
        }
    }
}
