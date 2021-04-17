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
        private List<Inventory> inventoriesDinamicki = new List<Inventory>();
        private List<Inventory> inventoriesStaticki = new List<Inventory>();
        private Director director = new Director();

        public InventarWindow()
        {
            InitializeComponent();

            //replacing from Sobe.json to Inventar.json
            List<RoomRecord> rooms = new List<RoomRecord>();
            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in rooms)
            {
                foreach (Inventory inventory in room.inventory)
                {
                    int existDinamicki = 0;
                    int existStaticki = 0;
                    foreach (Inventory i in inventoriesDinamicki)
                    {
                        if (i.Id == inventory.Id)
                        {
                            existDinamicki = 1;
                        } 
                    }
                    if (existDinamicki == 0 && inventory.InventoryType == Model.InventoryType.dinamicki)
                    {
                        inventoriesDinamicki.Add(inventory);
                    }
                    foreach (Inventory i in inventoriesStaticki)
                    {
                        if (i.Id == inventory.Id)
                        {
                            existDinamicki = 1;
                        }
                    }
                    if (existStaticki == 0 && inventory.InventoryType == Model.InventoryType.staticki)
                    {
                        inventoriesStaticki.Add(inventory);
                    }
                }
            }

            /*InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            inventoryStorage.saveToFile(inventoriesDinamicki, "Inventar.json");
            inventoryStorage.saveToFile(inventoriesStaticki, "Inventar.json");*/

            dinamickiData.ItemsSource = inventoriesDinamicki;
            statickiData.ItemsSource = inventoriesStaticki;
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
            int index = dinamickiData.SelectedIndex;
            Inventory selectedInventory = (Inventory)dinamickiData.SelectedItem;

            if (index < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
            }
            else
            {
                InventoryFileStorage storage = new InventoryFileStorage();
                storage.DeleteInventory(selectedInventory);
                dinamickiData.ItemsSource = storage.loadFromFile("Inventar.json");
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            int index = dinamickiData.SelectedIndex;
            Inventory selectedInventory = (Inventory)dinamickiData.SelectedItem;

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
            Inventory selectedInventory = (Inventory)dinamickiData.SelectedItem;
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
