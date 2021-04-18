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
        private string selectedPurposeFrom;
        private string selectedPurposeTo;
        private RoomRecord roomFrom = new RoomRecord();
        private RoomRecord roomTo = new RoomRecord();
        private int amount = 0;
        private Inventory selectedInventory = new Inventory();
        private string from;
        private string to;
        private List<RoomRecord> rooms = new List<RoomRecord>();

        public ChangeInventoryPlace(Inventory selected)
        {
            InitializeComponent();

            List<string> hospitalWardFrom = new List<string>();
            hospitalWardFrom.Add("Pedijatrija");
            hospitalWardFrom.Add("Ortopedija");
            hospitalWardFrom.Add("Ginekologija");
            hospitalWardFrom.Add("Urologija");
            hospitalWardFrom.Add("Magacin");

            List<string> hospitalWard = new List<string>();
            hospitalWard.Add("Pedijatrija");
            hospitalWard.Add("Ortopedija");
            hospitalWard.Add("Ginekologija");
            hospitalWard.Add("Urologija");

            wardFromBox.ItemsSource = hospitalWardFrom;
            wardFromBox.SelectedItem = "Pedijatrija";

            wardToBox.ItemsSource = hospitalWard;
            wardToBox.SelectedItem = "Pedijatrija";

            List<string> purpose = new List<string>();
            purpose.Add("Ordinacija");
            purpose.Add("Operaciona sala");
            purpose.Add("Soba");

            purposeFromBox.ItemsSource = purpose;
            purposeFromBox.SelectedItem = "Ordinacija";

            purposeToBox.ItemsSource = purpose;
            purposeToBox.SelectedItem = "Ordinacija";

            selectedInventory = selected;

        }

        private void wardFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardFrom = (string)combo.SelectedItem;

            if(selectedWardFrom == "Magacin")
            {
                purposeFromBox.IsEnabled = false;
                numberFromBox.IsEnabled = false;
            }

        }

        private void wardToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardTo = (string)combo.SelectedItem;

        }
        private void purposeFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedPurposeFrom = (string)combo.SelectedItem;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = new List<RoomRecord>();
            rooms = roomStorage.loadFromFile("Sobe.json");
            List<int> numbers = new List<int>();


            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard.Equals(wardFromBox.SelectedItem) && room.roomPurpose.Name.Equals(purposeFromBox.SelectedItem))
                {
                    numbers.Add(room.Id);
                }
            }

            numberFromBox.ItemsSource = numbers;
        }
        private void purposeToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedPurposeTo = (string)combo.SelectedItem;

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            List<RoomRecord> rooms = new List<RoomRecord>();
            rooms = roomStorage.loadFromFile("Sobe.json");
            List<int> numbers = new List<int>();


            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard.Equals(wardToBox.SelectedItem) && room.roomPurpose.Name.Equals(purposeToBox.SelectedItem))
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
            if(selectedWardFrom == "Magacin")
            {
                roomFrom.Id = 1;
            }
            else
            {
                roomFrom.Id = (int)Int64.Parse(from);
            }

            roomTo.Id = (int)Int64.Parse(to);
            amount = (int)Int64.Parse(amountBox.Text);

            RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
            rooms = roomStorage.loadFromFile("Sobe.json");

            roomFrom = FindRoomFrom(roomFrom.Id);
            roomTo = FindRoomTo(roomTo.Id);

            bool containsFrom = DoesRoomFromContains(roomFrom, selectedInventory.Id);
            bool enoughAmount = ContainsEnoughAmount(roomFrom, selectedInventory.Id, amount);
            bool containsTo = DoesRoomToContains(roomTo, selectedInventory.Id);

            if (containsFrom == true)
            {
                if(enoughAmount == true)
                {
                    ReduceTheAmount(roomFrom, selectedInventory.Id, amount);

                    if (containsTo == true)
                    {
                        IncreaseTheAmount(roomTo, selectedInventory.Id, amount);
                    }
                    else
                    {
                        InventoryFileStorage iStorage = new InventoryFileStorage();

                        selectedInventory.CurrentAmount = 0;
                        iStorage.AddInventoryInRoom(roomTo, selectedInventory);

                        IncreaseTheAmount(roomTo, selectedInventory.Id, amount);

                    }
                }
                else
                {
                    MessageBox.Show("Prostorija IZ koje želite da izvršite prebacivanje ne sadrži dovoljnu količinu ovog inventara");
                }
            }
            else
            {
                MessageBox.Show("Prostorija IZ koje želite da izvršite prebacivanje ne sadrži ovaj inventar");
            }

            roomStorage.saveToFile(rooms, "Sobe.json");

            SelectedInventoryInRooms sw = new SelectedInventoryInRooms(selectedInventory);
            sw.Show();
            this.Close();

        }

        private RoomRecord FindRoomFrom(int id)
        {
            RoomRecord roomFrom = new RoomRecord();

            foreach(RoomRecord room in rooms)
            {
                if(room.Id == id)
                {
                    roomFrom = room; ;
                }
            }

            return roomFrom;
        }

        private RoomRecord FindRoomTo(int id)
        {
            RoomRecord roomTo = new RoomRecord();

            foreach (RoomRecord room in rooms)
            {
                if (room.Id == id)
                {
                    roomTo = room; ;
                }
            }

            return roomTo;
        }

        private bool DoesRoomFromContains(RoomRecord room, int inventoryId)
        {
            int exist = 0;
            foreach(Inventory i in room.inventory)
            {
                if(i.Id == inventoryId)
                {
                    exist = 1;
                }
            }

            if (exist == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        private bool DoesRoomToContains(RoomRecord room, int inventoryId)
        {
            int exist = 0;
            foreach (Inventory i in room.inventory)
            {
                if (i.Id == inventoryId)
                {
                    exist = 1;
                }
            }

            if (exist == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool ContainsEnoughAmount(RoomRecord room, int inventoryId, int amount)
        {
            foreach(Inventory i in room.inventory)
            {
                if(i.Id == inventoryId)
                {
                    if(i.CurrentAmount >= amount)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        private void ReduceTheAmount(RoomRecord room, int inventoryId, int amount)
        {
            foreach(Inventory i in room.inventory)
            {
                if(i.Id == inventoryId)
                {
                    i.CurrentAmount -= amount;
                }
            }

        }
        private void IncreaseTheAmount(RoomRecord room, int inventoryId, int amount)
        {
            foreach (Inventory i in room.inventory)
            {
                if (i.Id == inventoryId)
                {
                    i.CurrentAmount += amount;
                }
            }

        }

    }
}
