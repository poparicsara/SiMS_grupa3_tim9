﻿using Model;
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
        private List<Room> rooms = new List<Room>();
        private string selectedDate;
        private int selectedHour;
        private int selectedMinute;
        private RoomRepository roomRepository = new RoomRepository();
        private Room roomFrom;
        private Room roomTo;
        private const int FROM = 1;
        private const int TO = 0;
        private Specialization spec = new Specialization();
        private RoomService roomService = new RoomService();
        private ChangeInventoryPlaceService changeService = new ChangeInventoryPlaceService();

        public ChangeInventoryPlace(Inventory selected)
        {
            InitializeComponent();

            rooms = roomRepository.GetRooms();

            wardFromBox.ItemsSource = GetHospitalWards(FROM);
            wardFromBox.SelectedItem = GetHospitalWards(FROM).ElementAt(0);
            wardToBox.ItemsSource = GetHospitalWards(TO);
            wardToBox.SelectedItem = GetHospitalWards(TO).ElementAt(0);

            purposeFromBox.ItemsSource = GetRoomPurposes();
            purposeFromBox.SelectedItem = GetRoomPurposes().ElementAt(0);
            purposeToBox.ItemsSource = GetRoomPurposes();
            purposeToBox.SelectedItem = GetRoomPurposes().ElementAt(0);

            selectedInventory = selected;

            if(selectedInventory.InventoryType == Model.InventoryType.dinamicki)
            {
                DisableTime();
            }
        }

        private List<string> GetHospitalWards(int room)
        {
            List<Specialization> specializations = spec.getSpecializations();           
            foreach(Specialization s in specializations)
            {
                hospitalWards.Add(s.Name);
            }
            if (room == FROM)
            {
                hospitalWards.Add("Magacin");
            }            
            return hospitalWards;
        }

        public List<string> GetRoomPurposes()
        {
            RoomPurpose purpose = new RoomPurpose();
            List<string> purposes = purpose.GetPurposes();
            return purposes;
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
            foreach (Room room in rooms)
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

        private void SettingValues(object sender, RoutedEventArgs e)
        {
            SetRooms();
            amount = (int)Int64.Parse(amountBox.Text);
            CheckRoomInventory();
            CheckAmount();
        }

        private void SetRooms()
        {
            roomFrom = roomService.GetRoom((int) Int64.Parse(from));
            roomTo = roomService.GetRoom((int)Int64.Parse(to));
        }

        private void CheckRoomInventory()
        {
            if (!changeService.HasRoomSelectedInventory(selectedInventory, roomFrom))
            {
                MessageBox.Show("Prostorija iz koje zelite da izvrsite preraspodelu ne sadrzi izabrani inventar!");
            }
        }

        private void CheckAmount()
        {
            if(!changeService.HasEnoughAmount(selectedInventory, roomFrom))
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
    }
}