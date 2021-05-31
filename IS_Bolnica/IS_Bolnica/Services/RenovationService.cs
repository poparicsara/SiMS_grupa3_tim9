﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class RenovationService
    {
        private RenovationRepository repository = new RenovationRepository();
        private List<Renovation> renovations = new List<Renovation>();
        private RoomRepository roomRepository = new RoomRepository();
        private RoomService roomService = new RoomService();
        private Room newRoom = new Room();
        private Thread thread;
        private int hourOfChange;
        private int minuteOfChange;
        private string dateOfChange;
        private Room room1;
        private Room room2;
        private bool merge = false;
        private bool separate = false;

        public RenovationService()
        {
            renovations = repository.GetRenovations();
        }

        public void AddRenovation(Renovation renovation)
        {
            repository.AddRenovation(renovation);
            CheckScheduledAppointments(renovation);
        }

        public void CheckScheduledAppointments(Renovation renovation)
        {
            AppointmentService appointmentService = new AppointmentService();
            List<Appointment> appointments = appointmentService.GetAppointments();
            foreach (var a in appointments)
            {
                CheckAppointment(renovation, a);
            }
        }

        private void CheckAppointment(Renovation renovation, Appointment a)
        {
            if (a.Room.Id == renovation.Room.Id)
            {
                if (IsStartDateInRenovationPeriod(a, renovation) || IsEndDateInRenovationPeriod(a, renovation))
                {
                    SendNotification(a);
                }
            }
        }

        private bool IsStartDateInRenovationPeriod(Appointment appointment, Renovation renovation)
        {
            return appointment.StartTime >= renovation.StartDate && appointment.StartTime <= renovation.EndDate;
        }

        private bool IsEndDateInRenovationPeriod(Appointment appointment, Renovation renovation)
        {
            return appointment.EndTime >= renovation.StartDate && appointment.EndTime <= renovation.EndDate;
        }

        private void SendNotification(Appointment appointment)
        {
            Notification notification = new Notification();
            SetNotificationAttributes(appointment, notification);
            NotificationService notificationService = new NotificationService();
            notificationService.AddNotification(notification);
        }

        private void SetNotificationAttributes(Appointment appointment, Notification notification)
        {
            notification.Title = "Pomeranje termina zbog renoviranja";
            SetNotificationContent(appointment, notification);
            notification.notificationType = NotificationType.secretory;
            notification.Sender = UserType.director;
        }

        private void SetNotificationContent(Appointment appointment, Notification notification)
        {
            notification.Content += "Potrebna je izmena termina: " + "\n";
            notification.Content += "\t" + "Tip termina: " + appointment.AppointmentType + "\n";
            notification.Content += "\t" + "Datum termina: " + appointment.StartTime + "\n";
            notification.Content = "\t" + "Prostorija: " + appointment.Room.Id + "\n";
            notification.Content += "\t" + "Pacijent: " + appointment.Patient.Name + " " + appointment.Patient.Surname + "\n";
            notification.Content += "\t" + "Doktor: " + appointment.Doctor.Name + " " + appointment.Patient.Surname + "\n";
        }

        public void MergeRooms(Room room1, Room room2, string startDate, string endDate, int hour, int minute, int roomNumber)
        {
            SetMergeAttributes(room1, room2, startDate, endDate, hour, minute, roomNumber);
            StartThread();
        }

        public void SeparateRoom(Room room1, string startDate, string endDate, int hour, int minute, int roomNumber)
        {
            SetSeparationAttributes(room1, startDate, endDate, hour, minute, roomNumber);
            StartThread();
        }

        private void SetSeparationAttributes(Room room1, string startDate, string endDate, int hour, int minute, int roomNumber)
        {
            separate = true;
            this.room1 = room1;
            SetNewRoom(roomNumber);
            room2 = newRoom;
            SetDateAttributes(endDate, hour, minute);
        }

        private void SetMergeAttributes(Room room1, Room room2, string startDate, string endDate, int hour, int minute, int roomNumber)
        {
            merge = true;
            SetDateAttributes(endDate, hour, minute);
            SetRooms(room1, room2, roomNumber);
        }

        private void SetDateAttributes(string endDate, int hour, int minute)
        {
            dateOfChange = endDate;
            hourOfChange = hour;
            minuteOfChange = minute;
        }

        private void SetRooms(Room room1, Room room2, int roomNumber)
        {
            this.room1 = room1;
            this.room2 = room2;
            SetNewRoom(roomNumber);
        }

        private void SetNewRoom(int id)
        {
            newRoom.Id = id;
            newRoom.HospitalWard = room1.HospitalWard;
            newRoom.roomPurpose = room1.roomPurpose;
            newRoom.inventory = new List<Inventory>();  //just empty list (not null)
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

        private void DoChange()
        {
            if (merge)
            {
                DoMerge();
            }
            else if (separate)
            {
                DoSeparation();
            }
        }

        private bool IsSelectedTime()
        {
            return GetCurrentDate().Equals(dateOfChange) && GetCurrentHour() == hourOfChange && GetCurrentMinute() == minuteOfChange;
        }

        private void DoMerge()
        {
            roomService.DeleteRoom(room1);
            roomService.DeleteRoom(room2);
            roomService.AddRoom(newRoom);
        }

        private void DoSeparation()
        {
            roomService.DeleteRoom(room1);
            roomService.AddRoom(room1);
            roomService.AddRoom(room2);
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
            else if (IsMidnight())
            {
                hour = 0;
            }
            return hour;
        }

        private int GetCurrentMinute()
        {
            int minute = (int)Int64.Parse(GetCurrentTime()[1]);
            return minute;
        }

        private bool IsMidnight()
        {
            if (GetCurrentTime()[0].Equals("12"))
            {
                return true;
            }
            return false;
        }

        private bool IsHourAM()
        {
            if (GetFullCurrentDate()[2].Equals("AM"))
            {
                return true;
            }
            return false;
        }

        public List<Renovation> GetRenovations()
        {
            return repository.GetRenovations();
        }
    }
}
