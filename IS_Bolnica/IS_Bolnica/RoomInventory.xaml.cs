using Model;
using System.Windows;
using System.Windows.Input;
using IS_Bolnica.GUI.Director.ViewModel;

namespace IS_Bolnica
{

    public partial class RoomInventory : Window
    {

        public RoomInventory(Room selectedRoom)
        {
            RoomInventoryViewModel viewModel = new RoomInventoryViewModel(selectedRoom);
            InitializeComponent();
            this.DataContext = viewModel;

        }

    }
}