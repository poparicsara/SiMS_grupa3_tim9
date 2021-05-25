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

namespace IS_Bolnica
{

    public partial class InventoryWindow : Window
    {
        private List<Inventory> dynamicInventories = new List<Inventory>();
        private List<Inventory> staticInventories = new List<Inventory>();
        private Director director = new Director();
        private List<Inventory> magacinInventory = new List<Inventory>();
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private RoomRecord magacin = new RoomRecord();
        private RoomRepository roomStorage = new RoomRepository();
        private Inventory selectedInventory = new Inventory();
        private InventoryFileStorage storage = new InventoryFileStorage();

        public InventoryWindow()
        {
            InitializeComponent();

            SetMagacin();
            SetDynamicAndStaticInventory();

            dynamicDataGrid.ItemsSource = dynamicInventories;
            staticDataGrid.ItemsSource = staticInventories;
        }

        private void SetMagacin()
        {
            rooms = roomStorage.loadFromFile("Sobe.json");
            foreach (RoomRecord r in rooms)
            {
                if (r.HospitalWard.Equals("Magacin"))
                {
                    magacin = r;
                }
            }
        }

        private void SetDynamicAndStaticInventory()
        {
            dynamicInventories = new List<Inventory>();
            staticInventories = new List<Inventory>();
            foreach(Inventory i in magacin.inventory)
            {
                SetInventoryType(i);
            }
        }

        private void SetInventoryType(Inventory i)
        {
            if (i.InventoryType == InventoryType.dinamicki)
            {
                dynamicInventories.Add(i);
            }
            else
            {
                staticInventories.Add(i);
            }
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
                storage.DeleteInventory(selectedInventory);
                RefreshDataGrid();
            }
        }

        private bool IsAnyDynamicInventorySelected()
        {
            if(dynamicDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
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
            SetMagacin();
            SetDynamicAndStaticInventory();
            dynamicDataGrid.ItemsSource = dynamicInventories;
            staticDataGrid.ItemsSource = staticInventories;
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
                storage.DeleteInventory(selectedInventory);
                RefreshDataGrid();
            }
        }

        private bool IsAnyStaticInventorySelected()
        {
            if (staticDataGrid.SelectedIndex < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
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
            InventoryPerRooms si = new InventoryPerRooms(selectedInventory);
            si.Show();
        }
        
        private void StaticRowDoubelClick(object sender, MouseButtonEventArgs e)
        {
            selectedInventory = (Inventory)staticDataGrid.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            InventoryPerRooms si = new InventoryPerRooms(selectedInventory);
            si.Show();
        }

        private void DynamicKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = dynamicInventories.Where(inventory => inventory.Name.ToLower().Contains(searchBox.Text.ToLower()));
            dynamicDataGrid.ItemsSource = filtered;
        }

        private void StaticKeyUp(object sender, KeyEventArgs e)
        {
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
            DirectorProfileWindow profileWindow = new DirectorProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}
