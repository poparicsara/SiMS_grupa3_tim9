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

        public SelectedInventoryInRooms(Inventory selectedInventory)
        {
            InitializeComponent();

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            InventoryInRoom inRoom = new InventoryInRoom();
            //only for "Ordinacija"
            foreach (RoomRecord room in rooms)
            {
                int exist = 0;
                int amount = 0;
                if (room.roomPurpose.Name == "Ordinacija")
                {
                    foreach(Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if(selectedInventory.Id == i.Id)
                        {
                            exist = 1;
                            amount = selectedInventory.CurrentAmount;
                        }
                    }
                    if (exist == 1)
                    {
                        inRoom.RoomNumber = room.Id;
                        inRoom.CurrentAmount = amount;
                        inRoomList.Add(inRoom);
                    }
                }               
            }
            selectedInventoryData.ItemsSource = inRoomList;
        }
    }
}
