using Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    public partial class InventoryPerRooms : Window
    {
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private List<InventoryInRoom> ordinationList = new List<InventoryInRoom>();
        private List<InventoryInRoom> operationRoomList = new List<InventoryInRoom>();
        private List<InventoryInRoom> roomList = new List<InventoryInRoom>();
        private Inventory selectedInventory = new Inventory();
        private InventoryInRoom inventory = new InventoryInRoom();
        private RoomPurpose purpose = new RoomPurpose();

        public InventoryPerRooms(Inventory selected)
        {
            InitializeComponent();

            selectedInventory = selected;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            SearchAllRooms();
            SetItemsSource();
        }

        private void SearchAllRooms()
        {
            foreach (RoomRecord room in rooms)
            {
                SetInventoryAttributes(room);
            }
        }

        private void SetItemsSource()
        {
            ordinationDataGrid.ItemsSource = ordinationList;
            operationRoomDataGrid.ItemsSource = operationRoomList;
            roomDataGrid.ItemsSource = roomList;
        }

        private void SetInventoryAttributes(RoomRecord room)
        {
            inventory = new InventoryInRoom();
            inventory.Room = room;
            if (HasInventory())
            {
                if (HasSelectedInventory())
                {
                    AddToRightList();
                }
            }
        }

        private bool HasInventory()
        {
            if(inventory.Room.inventory != null)
            {
                return true;
            }
            return false;
        }

        private bool HasSelectedInventory()
        {
            foreach(Inventory i in inventory.Room.inventory)
            {
                if(i.Id == selectedInventory.Id)
                {
                    inventory.Inventory = i;
                    return true;
                }
            }
            return false;
        }

        private void AddToRightList()
        {
            String purpose = inventory.Room.roomPurpose.Name;
            if (purpose.Equals("Ordinacija"))
            {
                ordinationList.Add(inventory);
            }
            else if(purpose.Equals("Operaciona sala"))
            {
                operationRoomList.Add(inventory);
            }
            else if(purpose.Equals("Soba"))
            {
                roomList.Add(inventory);
            }
            else
            {
                SetMagacinTabContent();
            }
        }

        private void SetMagacinTabContent()
        {
            currentAmount.Content = inventory.Inventory.CurrentAmount.ToString();
            minAmount.Content = inventory.Inventory.Minimum.ToString();
        }

        private void ChangeInventoryPlaceButtonClicked(object sender, RoutedEventArgs e)
        {
            ChangeInventoryPlace cw = new ChangeInventoryPlace(selectedInventory);
            cw.Show();
            this.Close();
        }

        private void OrdinationKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = ordinationList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(ordinationSearchBox.Text.ToLower()));
            ordinationDataGrid.ItemsSource = filtered;
        }

        private void OperationRoomKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = operationRoomList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(operationRoomSearchBox.Text.ToLower()));
            operationRoomDataGrid.ItemsSource = filtered;
        }

        private void RoomKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = roomList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(RoomSearchBox.Text.ToLower()));
            roomDataGrid.ItemsSource = filtered;
        }
    }
}
