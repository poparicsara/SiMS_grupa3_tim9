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
        private Merging merging = new Merging();

        public RenovationService()
        {
            mergings = mergeRepository.GetAll();
            separations = separationRepository.GetAll();
        }

        public void AddRenovation(Renovation renovation)
        {
            repository.Add(renovation);
            CheckScheduledAppointments(renovation);
        }

        private void CheckScheduledAppointments(Renovation renovation)
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

        public void MergeRooms(Merging merging)
        {
            SetMergeAttributes(merging);
            AddMerging();
            StartThread();
        }

        public void SeparateRoom(Separation separation)
        {
            SetSeparationAttributes(separation);
            AddSeparation();
            StartThread();
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
