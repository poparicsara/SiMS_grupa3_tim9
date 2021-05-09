using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;

namespace IS_Bolnica
{
    public partial class ChangeInventoryPlace : Window
    {
        private string selectedWardFrom;
        private string selectedWardTo;
        private string selectedPurposeFrom;
        private string selectedPurposeTo;
        private int amount;
        private Inventory selectedInventory;
        private string from;
        private string to;
        private List<RoomRecord> rooms = new List<RoomRecord>();
        private string selectedDate;
        private int selectedHour;
        private int selectedMinute;
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Inventory inventoryFrom = new Inventory();
        private Inventory inventoryTo = new Inventory();
        private Thread thread;
        private RoomRecord roomFrom;
        private RoomRecord roomTo;

        public ChangeInventoryPlace(Inventory selected)
        {
            InitializeComponent();

            rooms = roomStorage.loadFromFile("Sobe.json");

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

            if(selectedInventory.InventoryType == Model.InventoryType.dinamicki)
            {
                DisableTime();
            }
        }

        private void DisableTime()
        {
            dateofChange.IsEnabled = false;
            hourofChange.IsEnabled = false;
            minuteOfChange.IsEnabled = false;
        }

        private void wardFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardFrom = (string)combo.SelectedItem;
            IsMagacin();
        }

        private void IsMagacin()
        {
            if (selectedWardFrom == "Magacin")
            {
                from = "1";
                LockPurposeAndNumberBox();
            }
        }

        private void LockPurposeAndNumberBox()
        {
            purposeFromBox.IsEnabled = false;
            numberFromBox.IsEnabled = false;
        }

        private void purposeFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedPurposeFrom = (string)combo.SelectedItem;

            numberFromBox.ItemsSource = GetAppropriateRoomNumbers(selectedWardFrom, selectedPurposeFrom);
        }

        private List<int> GetAppropriateRoomNumbers(string hospitalWard, string roomPurpose)
        {
            List<int> roomNumbers = new List<int>();
            foreach (RoomRecord room in rooms)
            {
                if (room.HospitalWard.Equals(hospitalWard) && room.roomPurpose.Name.Equals(roomPurpose))
                {
                    roomNumbers.Add(room.Id);
                }
            }
            return roomNumbers;
        }

        private void numberFromChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            from = combo.SelectedItem.ToString();
        }

        private void wardToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedWardTo = (string)combo.SelectedItem;
        }

        private void purposeToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            selectedPurposeTo = (string)combo.SelectedItem;

            numberToBox.ItemsSource = GetAppropriateRoomNumbers(selectedWardTo, selectedPurposeTo);
        }

        private void numberToChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            to = combo.SelectedItem.ToString();
        }

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void SetAmount()
        {
            amount = (int)Int64.Parse(amountBox.Text);
        }

        private void SettingValues(object sender, RoutedEventArgs e)
        {
            SetRooms();
            SetAmount();
            SetInventories();
            CheckAmount();
        }

        private void SetRooms()
        {
            foreach (RoomRecord r in rooms)
            {
                if (r.Id == (int)Int64.Parse(from))
                {
                    roomFrom = r;
                }
                else if(r.Id == (int)Int64.Parse(to))
                {
                    roomTo = r;
                }
            }
        }

        private void SetInventories()
        {
            SetInventoryFrom(roomFrom);
            SetInventoryTo(roomTo);
        }

        private void CheckInventoryType()
        {
            if(selectedInventory.InventoryType == Model.InventoryType.staticki)
            {
                StartThread();
            }
            else
            {
                DoChange();
            }
            this.Close();
        }

        private void SetInventoryFrom(RoomRecord room)
        {
            if(FindInventory(room) != null)
            {
                inventoryFrom = FindInventory(room);
            }
            else
            {
                MessageBox.Show("Prostorija iz koje zelite da izvrsite preraspodelu ne sadrzi izabrani inventar!");
            }
        }

        private void SetInventoryTo(RoomRecord room)
        {
            if (FindInventory(room) != null)
            {
                inventoryTo = FindInventory(room);
            }
            else
            {
                AddInventory();
                inventoryTo = FindInventory(room);
            }
        }

        private void AddInventory()
        {
            InventoryFileStorage inventoryStorage = new InventoryFileStorage();
            inventoryStorage.AddInventoryInRoom(roomTo, selectedInventory);
        }

        private Inventory FindInventory(RoomRecord room)
        {
            Inventory inventory = null;
            foreach (Inventory i in room.inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    inventory = i;
                }
            }
            return inventory;
        }

        private void CheckAmount()
        {
            if(inventoryFrom.CurrentAmount < amount)
            {
                MessageBox.Show("Prostorija iz koje zelite da izvrsite preraspodelu ne sadrzi dovoljnu kolicinu izabranog inventara");
            }
            else
            {
                CheckInventoryType();
            }
        }

        private void ReduceAmount()
        {
            inventoryFrom.CurrentAmount -= amount;
        }
        private void IncreaseAmount()
        {
            inventoryTo.CurrentAmount += amount;
        }

        private void StartThread()
        {
            thread = new Thread(new ThreadStart(CheckingTime));
            thread.Start();
        }

        private void CheckingTime()
        {
            while (true)
            {
                if (IsSelectedTime())
                {
                    DoChange();
                    thread.Abort();
                }
                Thread.Sleep(TimeSpan.FromSeconds(59));
            } 
        }

        private bool IsSelectedTime()
        {
            return GetCurrentDate().Equals(selectedDate) && GetCurrentHour() == selectedHour && GetCurrentMinute() == selectedMinute;
        }

        private void DoChange()
        {
            ReduceAmount();
            IncreaseAmount();
            roomStorage.saveToFile(rooms, "Sobe.json");
        }

        private string[] GetFullCurrentDate()
        {
            DateTime currentTime = DateTime.Now;
            string[] time = currentTime.ToString().Split(' ');
            return time;
        }

        private string GetCurrentDate()
        {
            string date = GetFullCurrentDate()[0];
            return date;
        }

        private string[] GetCurrentTime()
        {
            string[] time = GetFullCurrentDate()[1].Split(':');
            return time;
        }

        private int GetCurrentHour()
        {
            int hour = (int)Int64.Parse(GetCurrentTime()[0]);
            if (!IsHourAM())
            {
                hour += 12;
            }
            return hour;
        }

        private int GetCurrentMinute()
        {
            int minute = (int)Int64.Parse(GetCurrentTime()[1]);
            return minute;
        }

        private bool IsHourAM()
        {
            if (GetFullCurrentDate()[2].Equals("AM"))
            {
                return true;
            }
            return false;
        }

        private void hourChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string hour = combo.SelectedItem.ToString();
            string[] temp = hour.Split(' ');
            int.TryParse(temp[1], out selectedHour);
        }

        private void minuteChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            string minute = combo.SelectedItem.ToString();
            string[] temp = minute.Split(' ');
            int.TryParse(temp[1], out selectedMinute);
        }

        private void dateChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as DatePicker;
            string fullDate = dateofChange.SelectedDate.ToString();
            string[] dateParts = fullDate.Split(' ');
            selectedDate = dateParts[0];
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SelectedInventoryInRooms sw = new SelectedInventoryInRooms(selectedInventory);
            sw.Show();
        }
    }
}
