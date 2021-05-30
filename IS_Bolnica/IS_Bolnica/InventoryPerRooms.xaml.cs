using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class InventoryPerRooms : Window
    {
        private Inventory selectedInventory = new Inventory();
        private InventoryInRoom inventory = new InventoryInRoom();
        private InventoryPerRoomService service;

        public InventoryPerRooms(Inventory selected)
        {
            InitializeComponent();

            selectedInventory = selected;

            service = new InventoryPerRoomService(selectedInventory);

            SetItemsSource();
        }

        private void SetItemsSource()
        {
            ordinationDataGrid.ItemsSource = service.GetOrdinationsWithInventory();
            operationRoomDataGrid.ItemsSource = service.GetOperationRoomWithInventory();
            roomDataGrid.ItemsSource = service.GetRoomsWithInventory();
            SetMagacinTabContent();
        }

        private void SetMagacinTabContent()
        {
            currentAmount.Content = service.GetMagacinAmount();
            minAmount.Content = service.GetMagacinMinimum();
        }

        private void ChangeInventoryPlaceButtonClicked(object sender, RoutedEventArgs e)
        {
            ChangeInventoryPlace cw = new ChangeInventoryPlace(selectedInventory);
            cw.Show();
            this.Close();
        }

        private void OrdinationKeyUp(object sender, KeyEventArgs e)
        {
            List<InventoryInRoom> ordinationList = service.GetOrdinationsWithInventory();
            var filtered = ordinationList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(ordinationSearchBox.Text.ToLower()));
            ordinationDataGrid.ItemsSource = filtered;
        }

        private void OperationRoomKeyUp(object sender, KeyEventArgs e)
        {
            List<InventoryInRoom> operationRoomList = service.GetOperationRoomWithInventory();
            var filtered = operationRoomList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(operationRoomSearchBox.Text.ToLower()));
            operationRoomDataGrid.ItemsSource = filtered;
        }

        private void RoomKeyUp(object sender, KeyEventArgs e)
        {
            List<InventoryInRoom> roomList = service.GetRoomsWithInventory();
            var filtered = roomList.Where(inventory => inventory.Room.HospitalWard.ToLower().StartsWith(RoomSearchBox.Text.ToLower()));
            roomDataGrid.ItemsSource = filtered;
        }
    }
}
