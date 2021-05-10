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
        private List<InventoryInRoom> inRoomListOrdinacija = new List<InventoryInRoom>();
        private List<InventoryInRoom> inRoomListOperacionaSala = new List<InventoryInRoom>();
        private List<InventoryInRoom> inRoomListSoba = new List<InventoryInRoom>();
        private Inventory selected = new Inventory();

        public SelectedInventoryInRooms(Inventory selectedInventory)
        {
            InitializeComponent();

            selected = selectedInventory;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            
            foreach (RoomRecord room in rooms)
            {
                InventoryInRoom inRoom = new InventoryInRoom();
                int existOr = 0;
                int amountOr = 0;
                string wardOr = "";
                int existOp = 0;
                int amountOp = 0;
                string wardOp = "";
                int existS = 0;
                int amountS = 0;
                string wardS = "";
                if (room.roomPurpose.Name == "Ordinacija")
                {
                    wardOr = room.HospitalWard;
                    if(room.inventory == null)
                    {
                        break;
                    }
                    foreach(Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if(i.Id == selectedInventory.Id)
                        {
                            existOr = 1;
                            amountOr = i.CurrentAmount;
                        }
                    }
                }
                else if (room.roomPurpose.Name == "Operaciona sala")
                {
                    wardOp = room.HospitalWard;
                    if (room.inventory == null)
                    {
                        break;
                    }
                    foreach (Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if (i.Id == selectedInventory.Id)
                        {
                            existOp = 1;
                            amountOp = i.CurrentAmount;
                        }
                    }
                }
                else if(room.roomPurpose.Name == "Soba")
                {
                    wardS = room.HospitalWard;
                    if (room.inventory == null)
                    {
                        break;
                    }
                    foreach (Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if (i.Id == selectedInventory.Id)
                        {
                            existS = 1;
                            amountS = i.CurrentAmount;
                        }
                    }
                }
                else if(room.HospitalWard == "Magacin")
                {
                    if (room.inventory == null)
                    {
                        break;
                    }
                    foreach (Inventory i in room.inventory)  // da ga nadjemo
                    {
                        if (i.Id == selectedInventory.Id)
                        {
                            currentAmount.Content = i.CurrentAmount.ToString();
                            minAmount.Content = i.Minimum.ToString();
                        }
                    }
                }
                if (existOr == 1)
                {
                    inRoom.RoomNumber = room.Id;
                    inRoom.CurrentAmount = amountOr;
                    inRoom.HospitalWard = wardOr;
                    inRoomListOrdinacija.Add(inRoom);
                }
                else if(existOp == 1)
                {
                    inRoom.RoomNumber = room.Id;
                    inRoom.CurrentAmount = amountOp;
                    inRoom.HospitalWard = wardOp;
                    inRoomListOperacionaSala.Add(inRoom);
                }
                else if(existS == 1)
                {
                    inRoom.RoomNumber = room.Id;
                    inRoom.CurrentAmount = amountS;
                    inRoom.HospitalWard = wardS;
                    inRoomListSoba.Add(inRoom);
                }
            }

            selectedInventoryOrdinacija.ItemsSource = inRoomListOrdinacija;
            selectedInventoryOperacionaSala.ItemsSource = inRoomListOperacionaSala;
            selectedInventorySoba.ItemsSource = inRoomListSoba;

        }

        private void ChangeButton(object sender, RoutedEventArgs e)
        {
            ChangeInventoryPlace cw = new ChangeInventoryPlace(selected);
            cw.Show();
            this.Close();
        }

        private void ordinacijaKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = inRoomListOrdinacija.Where(inventory => inventory.HospitalWard.ToLower().StartsWith(ordinacijaSearchBox.Text.ToLower()));

            selectedInventoryOrdinacija.ItemsSource = filtered;
        }

        private void operacionaKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = inRoomListOperacionaSala.Where(inventory => inventory.HospitalWard.ToLower().StartsWith(operacionaSearchBox.Text.ToLower()));

            selectedInventoryOperacionaSala.ItemsSource = filtered;
        }

        private void sobaKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = inRoomListSoba.Where(inventory => inventory.HospitalWard.ToLower().StartsWith(sobaSearchBox.Text.ToLower()));

            selectedInventorySoba.ItemsSource = filtered;
        }
    }
}
