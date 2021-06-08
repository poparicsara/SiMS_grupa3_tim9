using IS_Bolnica.Model;
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
using IS_Bolnica.Services;

namespace IS_Bolnica
{

    public partial class InventoryWindow : Window
    {
        private Inventory selectedInventory = new Inventory();
        private InventoryService service = new InventoryService();

        public InventoryWindow()
        {
            InitializeComponent();

            dynamicDataGrid.ItemsSource = service.GetDynamicInventory();
            staticDataGrid.ItemsSource = service.GetStaticInventory();
        }

        private void AddDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow("dinamicki");
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyDynamicInventorySelected())
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da obrišete izabrani inventar?",
                    "Brisanje inventara", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        service.DeleteInventory(selectedInventory);
                        RefreshDataGrid();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private bool IsAnyDynamicInventorySelected()
        {
            if(dynamicDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan dinamički inventar!");
                return false;
            }
            else
            {
                selectedInventory = (Inventory)dynamicDataGrid.SelectedItem;
                return true;
            }
        }

        private void RefreshDataGrid()
        {
            dynamicDataGrid.ItemsSource = service.GetDynamicInventory();
            staticDataGrid.ItemsSource = service.GetStaticInventory();
        }

        private void EditDynamicButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyDynamicInventorySelected())
            {
                EditInventoryWindow ew = new EditInventoryWindow(selectedInventory);
                ew.Show();
                this.Close();
            }
        }

        private void AddStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow("staticki");
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyStaticInventorySelected())
            {
                service.DeleteInventory(selectedInventory);
                RefreshDataGrid();
            }
        }

        private bool IsAnyStaticInventorySelected()
        {
            if (staticDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan statički inventar!");
                return false;
            }
            else
            {
                selectedInventory = (Inventory)staticDataGrid.SelectedItem;
                return true;
            }
        }

        private void EditStaticButtonClicked(object sender, RoutedEventArgs e)
        {
            if (IsAnyStaticInventorySelected())
            {
                EditInventoryWindow ew = new EditInventoryWindow(selectedInventory);
                ew.Show();
                this.Close();
            }
        }

        private void DynamicRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedInventory = (Inventory)dynamicDataGrid.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            InventoryPerRooms iw = new InventoryPerRooms(selectedInventory);
            iw.Show();
        }

        private void InventoryPerRoomDynamicButton(object sender, RoutedEventArgs e)
        {
            if (IsAnyDynamicInventorySelected())
            {
                selectedInventory = (Inventory)dynamicDataGrid.SelectedItem;
                DataGridRow row = sender as DataGridRow;
                InventoryPerRooms iw = new InventoryPerRooms(selectedInventory);
                iw.Show();
            }
        }

        private void InventoryPerRoomStaticButton(object sender, RoutedEventArgs e)
        {
            if (IsAnyStaticInventorySelected())
            {
                selectedInventory = (Inventory)staticDataGrid.SelectedItem;
                DataGridRow row = sender as DataGridRow;
                InventoryPerRooms iw = new InventoryPerRooms(selectedInventory);
                iw.Show();
            }
        }

        private void StaticRowDoubleClick(object sender, MouseButtonEventArgs e)
        {
            selectedInventory = (Inventory)staticDataGrid.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            InventoryPerRooms iw = new InventoryPerRooms(selectedInventory);
            iw.Show();
        }

        private void DynamicKeyUp(object sender, KeyEventArgs e)
        {
            List<Inventory> dynamicInventories = service.GetDynamicInventory();
            var filtered = dynamicInventories.Where(inventory => inventory.Name.ToLower().Contains(searchBox.Text.ToLower()));
            dynamicDataGrid.ItemsSource = filtered;
        }

        private void StaticKeyUp(object sender, KeyEventArgs e)
        {
            List<Inventory> staticInventories = service.GetStaticInventory();
            var filtered = staticInventories.Where(inventory => inventory.Name.ToLower().Contains(searchBox.Text.ToLower()));
            staticDataGrid.ItemsSource = filtered;
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow medicamentWindow = new MedicamentWindow();
            medicamentWindow.Show();
            this.Close();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            RoomWindow uw = new RoomWindow(director);
            uw.Show();
            this.Close();
        }

        private void ProfileButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow("0601234567", "ivanivanovic@gmail.com");
            profileWindow.Show();
            this.Close();
        }

    }
}
