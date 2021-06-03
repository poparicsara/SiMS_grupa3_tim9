using Model;
using System.Windows;
using System.Windows.Input;

namespace IS_Bolnica
{

    public partial class RoomInventory : Window
    {
        private InventoryRepository repository = new InventoryRepository();

        public RoomInventory(Room selectedRoom)
        {
            InitializeComponent();

            inventoryDataGrid.ItemsSource = repository.GetRoomInventory(selectedRoom);

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }
    }
}