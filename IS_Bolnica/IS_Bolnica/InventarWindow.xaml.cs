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

    public partial class InventarWindow : Window
    {
        private List<Inventory> inventories = new List<Inventory>();
        private Director director = new Director();

        public InventarWindow()
        {
            InitializeComponent();

            //replacing from Sobe.json to Inventar.json
            /*List<RoomRecord> rooms = new List<RoomRecord>();
            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            
            foreach(RoomRecord room in rooms)
            {
                foreach(Inventory inventory in room.inventory)
                {
                    int exist = 0;
                    foreach (Inventory i in inventories)
                    {
                        if(i.Id == inventory.Id)
                        {
                            exist = 1;
                        }
                    }
                    if(exist == 0)
                    {
                        inventories.Add(inventory);
                    }
                }
            }*/

            InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            //inventoryStorage.saveToFile(inventories, "Inventar.json");

            inventories = inventoryStorage.loadFromFile("Inventar.json");
            inventarData.ItemsSource = inventories;
        }

        private void inventarData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow();
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            Director director = (Director)DataContext;
            int index = inventarData.SelectedIndex;
            Inventory selectedInventory = (Inventory)inventarData.SelectedItem;

            if (index < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
            }
            else
            {
                InventoryFileStorage storage = new InventoryFileStorage();
                storage.DeleteInventory(selectedInventory);
                inventarData.ItemsSource = storage.loadFromFile("Inventar.json");
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            int index = inventarData.SelectedIndex;
            Inventory selectedInventory = (Inventory)inventarData.SelectedItem;

            if (index < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
            }
            else
            {
                EditInventoryWindow ew = new EditInventoryWindow(selectedInventory);
                ew.Show();
                this.Close();
            }
        }

        private void Row_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            Inventory selectedInventory = (Inventory)inventarData.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            SelectedInventoryInRooms si = new SelectedInventoryInRooms(selectedInventory);
            si.Show();
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //UpravnikWindow uw = new UpravnikWindow(director);
            //uw.Show();
        }
    }
}
