using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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

        public ChangeInventoryPlaceService()
        {
            rooms = roomService.GetRooms();
        }

        public bool HasRoomSelectedInventory(Inventory inventory, Room room)
        {
            return inventoryRepository.HasRoomSelectedInventory(room, inventory);
        }

        public bool HasEnoughAmount(Inventory inventory, Room room)
        {
            if (GetInventoryFromRoom(inventory, room) != null)
            {
                return true;
            }
            return false;
        }

        private Inventory GetInventoryFromRoom(Inventory selecteInventory, Room room)
        {
            foreach (var i in room.Inventory)
            {
                if (i.Id == selecteInventory.Id)
                {
                    return i;
                }
            }
            return null;
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

        private void CheckInventoryTo()
        {
            if (!HasRoomSelectedInventory(selectedInventory, roomTo))
            {
                inventoryRepository.AddInventoryToRoom(this.roomTo, selectedInventory);
                roomService.Save(rooms);
            }
            SetInventoryTo();
        }

        private void SetInventoryTo()
        {
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
                StartThread();
            }
            else
            {
                DoChange();
            }
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
            return GetCurrentDate().Equals(dateOfChange) && GetCurrentHour() == hourOfChange && GetCurrentMinute() == minuteOfChange;
        }

        private void DoChange()
        {
            inventoryFrom.CurrentAmount -= amount;
            inventoryTo.CurrentAmount += amount;
            roomService.Save(rooms);
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
    }
}
