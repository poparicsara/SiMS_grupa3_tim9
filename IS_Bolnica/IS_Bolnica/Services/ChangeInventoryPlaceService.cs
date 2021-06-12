using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class ChangeInventoryPlaceService
    {
        private Room roomFrom;
        private Room roomTo;
        private Inventory selectedInventory;
        private int amount;
        private Thread thread;
        private string dateOfChange;
        private int hourOfChange;
        private int minuteOfChange;
        private RoomService roomService = new RoomService();
        private List<Room> rooms;
        private Inventory inventoryFrom;
        private Inventory inventoryTo;
        private InventoryRepository inventoryRepository = new InventoryRepository();
        private List<Shifting> shiftings = new List<Shifting>();
        private Shifting newShifting = new Shifting();
        private RoomRepository roomRepository = new RoomRepository();

        public ChangeInventoryPlaceService()
        {
            rooms = roomService.GetRooms();
            shiftings = inventoryRepository.GetShiftings();
        }

        public bool HasRoomSelectedInventory(Inventory inventory, Room room)
        {
            room = roomRepository.FindById(room.Id);
            HasRoomAnyInventory(room);
            foreach (var i in room.Inventory)
            {
                if (i.Id == inventory.Id)
                {
                    return true;
                }
            }
            return false;
        }

        private static void HasRoomAnyInventory(Room room)
        {
            if (room.Inventory == null)
            {
                room.Inventory = new List<Inventory>();
            }
        }

        public bool HasEnoughAmount(Inventory inventory, Room room, int amount)
        {
            Inventory i = GetInventoryFromRoom(inventory, room);
            if (i != null)
            {
                if (i.CurrentAmount >= amount)
                {
                    return true;
                }
                return false;
            }
            return false;
        }


        public void ChangePlaceOfInventory(Room roomFrom, Room roomTo, Inventory selectedInventory, int amount, string date, int hour, int minute)
        {
            SetAttributes(roomFrom, roomTo, selectedInventory, amount, date, hour, minute);
            CheckInventoryType();
        }

        private void SetAttributes(Room roomFrom, Room roomTo, Inventory selectedInventory, int amount, string date, int hour, int minute)
        {
            SetRooms(roomFrom, roomTo);
            SetInventories(selectedInventory);
            this.amount = amount;
            SetDate(date, hour, minute);
        }

        private void SetRooms(Room roomFrom, Room roomTo)
        {
            foreach (var r in rooms)
            {
                if (r.Id == roomFrom.Id)
                {
                    this.roomFrom = r;
                }
                else if (r.Id == roomTo.Id)
                {
                    this.roomTo = r;
                }
            }
        }

        private void SetInventories(Inventory selectedInventory)
        {
            this.selectedInventory = selectedInventory;
            SetInventoryFrom();
            CheckInventoryTo();
        }

        private void SetInventoryFrom()
        {
            foreach (var i in roomFrom.Inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    inventoryFrom = i;
                }
            }
        }

        private Inventory GetInventoryFromRoom(Inventory selectedInventory, Room room)
        {
            room = roomRepository.FindById(room.Id);
            foreach (var i in room.Inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    return i;
                }
            }
            return null;
        }

        private void CheckInventoryTo()
        {
            if (!HasRoomSelectedInventory(selectedInventory, roomTo))
            {
                inventoryRepository.AddInventoryToRoom(this.roomTo, selectedInventory);
            }
            SetInventoryTo();
        }

        private void SetInventoryTo()
        {
            roomTo = roomRepository.FindById(roomTo.Id);
            foreach (var i in roomTo.Inventory)
            {
                if (i.Id == selectedInventory.Id)
                {
                    inventoryTo = i;
                }
            }
        }

        private void SetDate(string date, int hour, int minute)
        {
            this.dateOfChange = date;
            this.hourOfChange = hour;
            this.minuteOfChange = minute;
        }

        private void CheckInventoryType()
        {
            if (selectedInventory.InventoryType == InventoryType.staticki)
            {
                AddShifting();
                StartThread();
            }
            else
            {
                DoChange();
            }
        }

        private void AddShifting()
        {
            newShifting = new Shifting { RoomFrom = roomFrom, RoomTo = roomTo, Amount = amount, Date = dateOfChange, Hour = hourOfChange, Inventory = selectedInventory, Minute = minuteOfChange, Executed = false};
            inventoryRepository.AddShifting(newShifting);
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
                if (IsSelectedTime() || HasTimeOfChangePassed())
                {
                    DoChange();
                    EditShifting();
                    thread.Abort();
                }
                Thread.Sleep(TimeSpan.FromSeconds(59));
            }
        }

        private bool IsSelectedTime()
        {
            return GetCurrentDate().Equals(dateOfChange) && GetCurrentHour() == hourOfChange && GetCurrentMinute() == minuteOfChange;
        }

        private bool HasTimeOfChangePassed()
        {
            string fullDate = dateOfChange + " " + hourOfChange + ":" + minuteOfChange;
            DateTime fullDateOfChange = Convert.ToDateTime(fullDate);
            DateTime currentDate = DateTime.Now;
            if (fullDateOfChange < currentDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DoChange()
        {
            inventoryRepository.ReduceAmount(roomFrom, selectedInventory, amount);
            inventoryRepository.IncreaseAmount(roomTo, selectedInventory, amount);
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

        public void CheckUnexecutedShiftings()
        {
            shiftings = GetShiftings();
            foreach (var s in shiftings)
            {
                if (!s.Executed)
                {
                    SetAttributes(s.RoomFrom, s.RoomTo, s.Inventory, s.Amount, s.Date, s.Hour, s.Minute);
                    StartThread();
                }
            }
        }

        private int GetShiftingIndex()
        {
            var index = 0;
            shiftings = GetShiftings();
            foreach (var s in shiftings)
            {
                if (roomFrom.Id == s.RoomFrom.Id && roomTo.Id == s.RoomTo.Id && selectedInventory.Id == s.Inventory.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        private void EditShifting()
        {
            int index = GetShiftingIndex();
            inventoryRepository.EditShifting(index);
        }

        private List<Shifting> GetShiftings()
        {
            return inventoryRepository.GetShiftings();
        }
    }
}
