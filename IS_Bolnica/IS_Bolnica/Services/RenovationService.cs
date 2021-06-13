using System;
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
        private RoomService roomService = new RoomService();
        private Room newRoom = new Room();
        private Thread thread;
        private Thread separationThreat;
        private int hourOfChange;
        private int minuteOfChange;
        private string dateOfChange;
        private string startDate;
        private Room room1;
        private Room room2;
        private bool merge = false;
        private bool separate = false;
        private List<Merging> mergings = new List<Merging>();
        private List<Separation> separations = new List<Separation>();
        private MergingRepository mergeRepository = new MergingRepository();
        private SeparationRepository separationRepository = new SeparationRepository();
        private AppointmentService appointmentService = new AppointmentService();
        private ChangeInventoryPlaceService changeService = new ChangeInventoryPlaceService();

        public RenovationService()
        {
            mergings = mergeRepository.GetAll();
            separations = separationRepository.GetAll();
        }

        public void AddRenovation(Renovation renovation)
        {
            repository.Add(renovation);
            if (renovation.Room.Inventory != null)
            {
                ReplaceInventory(renovation);
            }
            CheckScheduledAppointments(renovation);
        }

        private void ReplaceInventory(Renovation renovation)
        {
            foreach (var i in renovation.Room.Inventory)
            {
                if (i.CurrentAmount > 0)
                {
                    changeService.MoveToMagacin(i, i.CurrentAmount, renovation.Room);
                }
            }
        }

        private void CheckScheduledAppointments(Renovation renovation)
        {
            List<Appointment> appointments = appointmentService.GetAppointments();
            foreach (var a in appointments)
            {
                CheckAppointment(renovation, a);
            }
        }

        public bool IsAppointmentBetweenAnyRenovation(Appointment appointment)
        {
            if (CheckRenovations(appointment)) return true;

            if (CheckMergings(appointment)) return true;

            if (CheckSeparations(appointment)) return true;

            return false;
        }

        private bool CheckSeparations(Appointment appointment)
        {
            foreach (var s in separationRepository.GetAll())
            {
                if (s.Room.Id == appointment.Room.Id)
                {
                    Renovation r = GetRenovationFromSeparation(s);
                    if (IsStartDateInRenovationPeriod(appointment, r) || IsEndDateInRenovationPeriod(appointment, r))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckMergings(Appointment appointment)
        {
            foreach (var m in mergeRepository.GetAll())
            {
                if (m.Room1.Id == appointment.Room.Id)
                {
                    Renovation r1 = GetRenovationFromMerging(m, m.Room1);
                    if (IsStartDateInRenovationPeriod(appointment, r1) || IsEndDateInRenovationPeriod(appointment, r1))
                    {
                        return true;
                    }
                }

                if (m.Room2.Id == appointment.Room.Id)
                {
                    Renovation r2 = GetRenovationFromMerging(m, m.Room2);
                    if (IsStartDateInRenovationPeriod(appointment, r2) || IsEndDateInRenovationPeriod(appointment, r2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckRenovations(Appointment appointment)
        {
            foreach (var r in repository.GetAll())
            {
                if (r.Room.Id == appointment.Room.Id)
                {
                    if (IsStartDateInRenovationPeriod(appointment, r) || IsEndDateInRenovationPeriod(appointment, r))
                    {
                        return true;
                    }
                }
            }

            return false;
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

        public void MergeRooms(Merging merging)
        {
            SetMergeAttributes(merging);
            AddMerging();
            CompareMergingWithAppointments(merging);
            ReplaceRoomInventory(merging.Room1);
            ReplaceRoomInventory(merging.Room2);
            StartThread();
        }

        public void SeparateRoom(Separation separation)
        {
            SetSeparationAttributes(separation);
            AddSeparation();
            CompareSeparationWithAppointments(separation);
            ReplaceRoomInventory(separation.Room);
            StartThread();
        }

        private void ReplaceRoomInventory(Room room)
        {
            if (room.Inventory != null)
            {
                foreach (var i in room.Inventory)
                {
                    if (i.CurrentAmount > 0)
                    {
                        changeService.MoveToMagacin(i, i.CurrentAmount, room);
                    }
                }
            }
        }

        private void SetSeparationAttributes(Separation separation)
        {
            separate = true;
            this.room1 = separation.Room;
            SetNewRoom(separation.NewRoomNumber);
            room2 = newRoom;
            SetDateAttributes(separation.StartDate, separation.EndDate, separation.Hour, separation.Minute);
        }

        private void SetMergeAttributes(Merging merging)
        {
            merge = true;
            SetDateAttributes(merging.StartDate, merging.EndDate, merging.Hour, merging.Minute);
            SetRooms(merging);
        }

        private void SetDateAttributes(string startDate, string endDate, int hour, int minute)
        {
            this.startDate = startDate;
            dateOfChange = endDate;
            hourOfChange = hour;
            minuteOfChange = minute;
        }

        private void SetRooms(Merging merging)
        {
            this.room1 = merging.Room1;
            this.room2 = merging.Room2;
            SetNewRoom(merging.NewRoomNumber);
        }

        private void SetNewRoom(int id)
        {
            newRoom.Id = id;
            newRoom.HospitalWard = room1.HospitalWard;
            newRoom.RoomPurpose = room1.RoomPurpose;
            newRoom.Inventory = new List<Inventory>();  //just empty list (not null)
        }

        private void StartSeparationThread()
        {
            separationThreat = new Thread(new ThreadStart(CheckingTime));
            separationThreat.Start();
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
                EditMerging();
            }
            else if (separate)
            {
                DoSeparation();
                EditSeparation();
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

        private void DoMerge()
        {
            roomService.AddRoom(newRoom);
            roomService.DeleteRoom(room1);
            roomService.DeleteRoom(room2);
        }

        private void CompareMergingWithAppointments(Merging merging)
        {
            Renovation r1 = GetRenovationFromMerging(merging, merging.Room1);
            CheckScheduledAppointments(r1);
            Renovation r2 = GetRenovationFromMerging(merging, merging.Room2);
            CheckScheduledAppointments(r2);
        }

        private Renovation GetRenovationFromMerging(Merging merging, Room room)
        {
            string start = merging.StartDate + " " + 0 + ":" + 0;
            DateTime fullStartDate = Convert.ToDateTime(start);
            string end = merging.EndDate + " " + merging.Hour + ":" + merging.Minute;
            DateTime fullEndDate = Convert.ToDateTime(end);
            Renovation r = new Renovation { Room = room, StartDate = fullStartDate, EndDate = fullEndDate };
            return r;
        }

        private void CompareSeparationWithAppointments(Separation separation)
        {
            Renovation r = GetRenovationFromSeparation(separation);
            CheckScheduledAppointments(r);
        }

        private Renovation GetRenovationFromSeparation(Separation separation)
        {
            string start = separation.StartDate + " " + 0 + ":" + 0;
            DateTime fullStartDate = Convert.ToDateTime(start);
            string end = separation.EndDate + " " + separation.Hour + ":" + separation.Minute;
            DateTime fullEndDate = Convert.ToDateTime(end);
            Renovation r = new Renovation { Room = separation.Room, StartDate = fullStartDate, EndDate = fullEndDate };
            return r;
        }

        private void DoSeparation()
        {
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

        public void CheckUnexecutedMergings()
        {
            mergings = mergeRepository.GetAll();
            if (mergings != null)
            {
                foreach (var m in mergings)
                {
                    if (!m.Executed)
                    {
                        SetMergeAttributes(m);
                        StartThread();
                    }
                }
            }
        }

        private void AddMerging()
        {
            Merging newMerging = new Merging
            {
                Room1 = room1, Room2 = room2, StartDate = startDate, EndDate = dateOfChange, Hour = hourOfChange,
                Minute = minuteOfChange, NewRoomNumber = newRoom.Id
            };
            mergeRepository.Add(newMerging);
        }

        private void EditMerging()
        {
            int index = GetMergingIndex();
            mergeRepository.EditMerging(index);
        }

        private int GetMergingIndex()
        {
            var index = 0;
            mergings = mergeRepository.GetAll();
            foreach (var s in mergings)
            {
                if (room1.Id == s.Room1.Id && room2.Id == s.Room2.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        private void AddSeparation()
        {
            Separation newSeparation = new Separation
            {
                Room = room1,
                StartDate = startDate,
                EndDate = dateOfChange,
                Hour = hourOfChange,
                Minute = minuteOfChange,
                NewRoomNumber = newRoom.Id
            };
            separationRepository.Add(newSeparation);
        }

        private void EditSeparation()
        {
            int index = GetSeparationIndex();
            separationRepository.EditSeparation(index);
        }

        private int GetSeparationIndex()
        {
            var index = 0;
            separations = separationRepository.GetAll();
            foreach (var s in separations)
            {
                if (room1.Id == s.Room.Id)
                {
                    break;
                }
                index++;
            }
            return index;
        }

        public void CheckUnexecutedSeparations()
        {
            separations = separationRepository.GetAll();
            foreach (var separation in separations)
            {
                if (!separation.Executed)
                {
                    SetSeparationAttributes(separation);
                    StartThread();
                }
            }
        }

    }
}
