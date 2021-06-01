using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
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
        private Point startPoint = new Point();
        private Inventory selectedInventory = new Inventory();
        private InventoryPerRoomService service;
        private int index = -1;
        private InventoryInRoom inventory1;
        private InventoryInRoom inventory2;

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

        private void OrdinationDataGrid_OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }


        private void OrdinationDataGrid_OnMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ordinationDataGrid = sender as DataGrid;
               
                InventoryInRoom draggedInventory = (InventoryInRoom) ordinationDataGrid.SelectedItem;
                if (draggedInventory == null) return;


                DataObject dragData = new DataObject("myFormat", draggedInventory);
                DragDrop.DoDragDrop(ordinationDataGrid, dragData, DragDropEffects.Move);
                var element = (UIElement)e.Source;
                index = Grid.GetRow(element);
            }

            

        }

        private void OrdinationDataGrid_OnDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                InventoryInRoom inventory = e.Data.GetData("myFormat") as InventoryInRoom;
                //InventoryInRoom inventory1 = (InventoryInRoom) e.Source;x
                //Debug.WriteLine(inventory.Room.Id + " prva");
                //inventory2 = (InventoryInRoom)ordinationDataGrid.Items.GetItemAt(index);
                
                //Debug.WriteLine(inventory2.Room.Id + " druga");
                ChangeInventoryPlace inventoryPlace = new ChangeInventoryPlace(selectedInventory); 
                inventoryPlace.Show();
                this.Close();
                
            }
        }
    }
}
