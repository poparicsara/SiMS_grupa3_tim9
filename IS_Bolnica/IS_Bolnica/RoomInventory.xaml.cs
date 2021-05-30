using Model;
using System.Windows;

namespace IS_Bolnica
{

    public partial class RoomInventory : Window
    {
        private InventoryRepository repository = new InventoryRepository();

        public RoomInventory(Room selectedRoom)
        {
            InitializeComponent();

            inventoryDataGrid.ItemsSource = repository.GetRoomInventory(selectedRoom);
        }

    }
}