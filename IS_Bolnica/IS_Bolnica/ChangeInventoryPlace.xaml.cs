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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class ChangeInventoryPlace : Window
    {
        List<string> hospitalWards = new List<string>();
        private string selectedWardFrom;
        private string selectedWardTo;
        private string selectedPurposeFrom;
        private string selectedPurposeTo;
        private int amount;
        private Inventory selectedInventory;
        private string from;
        private string to;
        private string selectedDate;
        private int selectedHour;
        private int selectedMinute;
        private Room roomFrom;
        private Room roomTo;
        private RoomService roomService = new RoomService();
        private ChangeInventoryPlaceService changeService = new ChangeInventoryPlaceService();

        public ChangeInventoryPlace(Inventory selected)
        {
            InitializeComponent();

            wardFromBox.ItemsSource = GetWardsWithMagacin();
            wardToBox.ItemsSource = roomService.GetHospitalWards();

            purposeFromBox.ItemsSource = roomService.GetRoomPurposes();
            purposeToBox.ItemsSource = roomService.GetRoomPurposes();

            numberFromBox.ItemsSource = roomService.GetRoomNumbers();
            numberToBox.ItemsSource = roomService.GetRoomNumbers();

            selectedInventory = selected;

            if(selectedInventory.InventoryType == Model.InventoryType.dinamicki)
            {
                DisableTime();
            }

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }
        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private List<string> GetWardsWithMagacin()
        {
            hospitalWards = roomService.GetHospitalWards();
            hospitalWards.Add("Magacin");
            return hospitalWards;
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

            numberFromBox.ItemsSource = roomService.GetAppropriateRoomNumbers(selectedWardFrom, selectedPurposeFrom);
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

            numberToBox.ItemsSource = roomService.GetAppropriateRoomNumbers(selectedWardTo, selectedPurposeTo);
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

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (selectedInventory.InventoryType == InventoryType.dinamicki)
            {
                if (!IsAnythingNullDynamic())
                {
                    SetRooms();
                    amount = (int)Int64.Parse(amountBox.Text);
                    if (CheckRoomInventory())
                    {
                        CheckAmount();
                    }
                }
                else
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                }
            }
            else
            {
                if (!IsAnythingNullStatic())
                {
                    SetRooms();
                    amount = (int)Int64.Parse(amountBox.Text);
                    if (CheckRoomInventory())
                    {
                        CheckAmount();
                    }
                }
                else
                {
                    MessageBox.Show("Sva polja moraju biti popunjena!");
                }
            }
            
        }

        private bool IsAnythingNullDynamic()
        {
            return wardFromBox.SelectedItem == null || purposeFromBox.SelectedItem == null ||
                   numberFromBox.SelectedItem == null ||
                   wardToBox.SelectedItem == null || purposeFromBox.SelectedItem == null ||
                   numberToBox.SelectedItem == null || amountBox.Text.Equals("");
        }

        private bool IsAnythingNullStatic()
        {
            return wardFromBox.SelectedItem == null || purposeFromBox.SelectedItem == null ||
                   numberFromBox.SelectedItem == null ||
                   wardToBox.SelectedItem == null || purposeFromBox.SelectedItem == null ||
                   numberToBox.SelectedItem == null || amountBox.Text.Equals("") || dateofChange.SelectedDate == null || 
                   hourofChange.SelectedItem == null || minuteOfChange.SelectedItem == null;
        }

        private void SetRooms()
        {
            roomFrom = roomService.GetRoom((int) Int64.Parse(from));
            roomTo = roomService.GetRoom((int)Int64.Parse(to));
        }

        private bool CheckRoomInventory()
        {
            if (!changeService.HasRoomSelectedInventory(selectedInventory, roomFrom))
            {
                MessageBox.Show("Prostorija iz koje zelite da izvrsite preraspodelu ne sadrzi izabrani inventar!");
                return false;
            }
            return true;
        }

        private void CheckAmount()
        {
            if(!changeService.HasEnoughAmount(selectedInventory, roomFrom, amount))
            {
                MessageBox.Show("Prostorija iz koje zelite da izvrsite preraspodelu ne sadrzi dovoljnu kolicinu izabranog inventara");
            }
            else
            {
                changeService.ChangePlaceOfInventory(roomFrom, roomTo, selectedInventory, amount, selectedDate, selectedHour, selectedMinute);
                this.Close();
            }
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
            InventoryPerRooms sw = new InventoryPerRooms(selectedInventory);
            sw.Show();
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
