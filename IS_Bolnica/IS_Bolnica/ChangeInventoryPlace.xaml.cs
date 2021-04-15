using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class ChangeInventoryPlace : Window
    {
        private string selectedWardFrom;
        private string selectedWardTo;
        private RoomRecord roomFrom = new RoomRecord();
        private RoomRecord roomTo = new RoomRecord();
        private int amount = 0;
        private Inventory selectedInventory = new Inventory();
        private string from;
        private string to;

        public ChangeInventoryPlace(Inventory selected)
        {
            InitializeComponent();

            List<string> hospitalWard = new List<string>();
            hospitalWard.Add("Pedijatrija");
            hospitalWard.Add("Ortopedija");
            hospitalWard.Add("Ginekologija");
            hospitalWard.Add("Urologija");

            wardFromBox.ItemsSource = hospitalWard;
            wardFromBox.SelectedItem = "Pedijatrija";

            wardToBox.ItemsSource = hospitalWard;
            wardToBox.SelectedItem = "Pedijatrija";

            selectedInventory = selected;

        }

        private void wardFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardFrom = (string)combo.SelectedItem;

            roomFrom.HospitalWard = selectedWardFrom;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = new List<RoomRecord>();
            rooms = roomStorage.loadFromFile("Sobe.json");
            List<int> numbers = new List<int>();


            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard.Equals(wardFromBox.SelectedItem) && room.roomPurpose.Name == "Ordinacija")
                {
                    numbers.Add(room.Id);
                }
            }

            numberFromBox.ItemsSource = numbers;
        }

        private void wardToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardTo = (string)combo.SelectedItem;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = new List<RoomRecord>();
            rooms = roomStorage.loadFromFile("Sobe.json");
            List<int> numbers = new List<int>();

            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard.Equals(wardToBox.SelectedItem) && room.roomPurpose.Name == "Ordinacija")
                {
                    numbers.Add(room.Id);
                }
            }

            numberToBox.ItemsSource = numbers;
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void numberFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            from = combo.SelectedItem.ToString();
        }

        private void numberToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            to = combo.SelectedItem.ToString();
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            RoomPurpose p1 = new RoomPurpose { Name = "Ordinacija" };
            roomFrom.roomPurpose = p1;
            RoomPurpose p2 = new RoomPurpose { Name = "Ordinacija" };
            roomTo.roomPurpose = p2;

            roomFrom.Id = (int)Int64.Parse(from);
            roomTo.Id = (int)Int64.Parse(to);

            amount = (int)Int64.Parse(amountBox.Text);

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = roomStorage.loadFromFile("Sobe.json");
            List<Inventory> inventoriesTo = new List<Inventory>();

            foreach(RoomRecord room in rooms)   // inventar sobe u koju prerasporedjujemo
            {
                if(room.Id == roomTo.Id)
                {
                    foreach(Inventory i in room.inventory)  //uzmemo sav
                    {
                        inventoriesTo.Add(i);
                    }
                }
            }

            foreach(RoomRecord room in rooms)
            {
                if(room.Id == roomFrom.Id)
                {
                    foreach(Inventory i in room.inventory)
                    {
                        if(i.Id == selectedInventory.Id)
                        {
                            i.CurrentAmount -= amount;
                        }
                    }
                }
            }

            foreach(Inventory i in inventoriesTo)   //imamo njegov inventar azuriran
            {
                if(i.Id == selectedInventory.Id)
                {
                    i.CurrentAmount += amount;
                }
            }

            foreach(RoomRecord room in rooms)
            {
                if(room.Id == roomTo.Id)
                {
                    foreach(Inventory i in room.inventory.ToList())  //obrisem ih sve
                    {
                        room.inventory.Remove(i);
                    }
                    foreach(Inventory i in inventoriesTo)
                    {
                        room.inventory.Add(i);
                    }
                }
            }

            roomStorage.saveToFile(rooms, "Sobe.json");

            SelectedInventoryInRooms sw = new SelectedInventoryInRooms(selectedInventory);
            sw.Show();
            this.Close();
        }

    }
}
