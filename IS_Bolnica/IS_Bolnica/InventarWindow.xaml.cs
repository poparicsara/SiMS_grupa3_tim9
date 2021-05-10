using IS_Bolnica.Model;
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
        private List<Inventory> magacinInventory = new List<Inventory>();

        public InventarWindow()
        {
            InitializeComponent();

            //replacing from Sobe.json to Inventar.json
            List<RoomRecord> rooms = new List<RoomRecord>();
            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            //PRVO POKRETANJE -> sve iz ostalih soba u magacin(bez korpija)
           /* foreach (RoomRecord room in rooms)
            {
                foreach(Inventory iRoom in room.inventory)
                {
                    int exist = 0;
                    foreach(Inventory iMagacin in magacinInventory)
                    {
                        if(iMagacin.Id == iRoom.Id)
                        {
                            exist = 1;
                        }
                    }
                    if(exist == 0)
                    {
                        int id = iRoom.Id;
                        string name = iRoom.Name;
                        InventoryType type = iRoom.InventoryType;
                        int curr = 0;
                        int min = 0;
                        Inventory i = new Inventory { Id = id, Name = name, InventoryType = type, CurrentAmount = curr, Minimum = min};
                        magacinInventory.Add(i);
                    }
                }
            }

            //sve prebacimo u listu u fajlu
            foreach(RoomRecord room in rooms)
            {
                if(room.HospitalWard == "Magacin")
                {
                    foreach(Inventory i in magacinInventory)
                    {
                        room.inventory.Add(i);
                    }
                }
            }

            roomStorage.saveToFile(rooms, "Sobe.json");*/
           
            foreach(RoomRecord room in rooms)
            {
                if(room.HospitalWard == "Magacin")
                {
                    foreach (Inventory i in room.inventory)
                    {
                        if (i.InventoryType == InventoryType.dinamicki)
                        {
                            inventoriesDinamicki.Add(i);
                        }
                        else
                        {
                            inventoriesStaticki.Add(i);
                        }
                    }
                }
            }

            dinamickiData.ItemsSource = inventoriesDinamicki;
            statickiData.ItemsSource = inventoriesStaticki;

        }

        private void AddButton(object sender, RoutedEventArgs e)
        {
            String type = "dinamicki";
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow(type);
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

                RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
                List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");
                List<Inventory> source = new List<Inventory>();

                foreach(RoomRecord room in rooms)
                {
                    if(room.HospitalWard == "Magacin")
                    {
                        foreach(Inventory i in room.inventory)
                        {
                            if(i.InventoryType == InventoryType.dinamicki)
                            {
                                source.Add(i);
                            }
                        }
                    }
                }

                dinamickiData.ItemsSource = source;
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

        private void AddButtonStaticki(object sender, RoutedEventArgs e)
        {
            String type = "staticki";
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow(type);
            addInventoryWindow.Show();
            this.Close();
        }

        private void DeleteButtonStaticki(object sender, RoutedEventArgs e)
        {
            Director director = (Director)DataContext;
            int index = statickiData.SelectedIndex;
            Inventory selectedInventory = (Inventory)statickiData.SelectedItem;

            if (index < 0)
            {
                MessageBox.Show("Niste izabrali nijedan inventar!");
            }
            else
            {
                InventoryFileStorage storage = new InventoryFileStorage();
                storage.DeleteInventory(selectedInventory);

                RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
                List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");
                List<Inventory> source = new List<Inventory>();

                foreach (RoomRecord room in rooms)
                {
                    if (room.HospitalWard == "Magacin")
                    {
                        foreach (Inventory i in room.inventory)
                        {
                            if (i.InventoryType == InventoryType.staticki)
                            {
                                source.Add(i);
                            }
                        }
                    }
                }

                statickiData.ItemsSource = source;
            }
        }

        private void EditButtonStaticki(object sender, RoutedEventArgs e)
        {
            int index = statickiData.SelectedIndex;
            Inventory selectedInventory = (Inventory)statickiData.SelectedItem;

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
        
        private void RowStaticki_DoubleClik(object sender, MouseButtonEventArgs e)
        {
            Inventory selectedInventory = (Inventory)statickiData.SelectedItem;
            DataGridRow row = sender as DataGridRow;
            SelectedInventoryInRooms si = new SelectedInventoryInRooms(selectedInventory);
            si.Show();
        }


        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //UpravnikWindow uw = new UpravnikWindow(director);
            //uw.Show();
        }

        private void dinamickiKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = inventoriesDinamicki.Where(inventory => inventory.Name.ToLower().Contains(searchBox.Text.ToLower()));

            dinamickiData.ItemsSource = filtered;
        }

        private void statickiKeyUp(object sender, KeyEventArgs e)
        {
            var filtered = inventoriesStaticki.Where(inventory => inventory.Name.ToLower().Contains(searchBox.Text.ToLower()));

            dinamickiData.ItemsSource = filtered;
        }

        private void MedicamentButton(object sender, RoutedEventArgs e)
        {
            MedicamentWindow medicamentWindow = new MedicamentWindow();
            medicamentWindow.Show();
            this.Close();
        }

        private void RoomButton(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            UpravnikWindow uw = new UpravnikWindow(director);
            uw.Show();
            this.Close();
        }

        private void ProfilButton(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow();
            profileWindow.Show();
            this.Close();
        }
    }
}
