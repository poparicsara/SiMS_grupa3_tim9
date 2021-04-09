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

    public partial class InventoryWindow : Window
    {
        private List<Inventory> inventories = new List<Inventory>();
        private List<RoomRecord> rooms = new List<RoomRecord>();
        public InventoryWindow(RoomRecord selectedRoom)
        {
            InitializeComponent();

            RoomRecordFileStorage storage = new RoomRecordFileStorage();
            rooms = storage.loadFromFile("Sobe.json"); 

            foreach(RoomRecord room in rooms)
            {
                if(room.Id == selectedRoom.Id)
                {
                    inventories = selectedRoom.inventory;
                    break;
                }
            }

            inventoryBinding.ItemsSource = inventories;
        }
    }
}
