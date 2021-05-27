﻿using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
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
    public partial class RenovationWindow : Window
    {
        private Room room;
        private Operation operation = new Operation();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        private List<Operation> operations = new List<Operation>();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        private List<Examination> examinations = new List<Examination>();
        private List<Notification> notifications = new List<Notification>();
        private NotificationRepository notificationStorage = new NotificationRepository();

        public RenovationWindow(Room selectedRoom)
        {
            InitializeComponent();

            room = selectedRoom;
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            operations = operationStorage.loadFromFile("operations.json");

            operation.Room = room;

            DateTime start = (DateTime)startDate.SelectedDate;
            operation.Date = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);

            DateTime end = (DateTime)endDate.SelectedDate;
            operation.endTime = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);

            //does something already exist in this period
            examinations = examinationStorage.loadFromFile("examinations.json");

            notifications = notificationStorage.LoadFromFile("NotificationsFileStorage.json");

            CheckAppointments(notificationStorage);


            operations.Add(operation);
            operationStorage.saveToFile(operations, "operations.json");

            Director director = new Director();
            RoomWindow uw = new RoomWindow(director);
            uw.Show();
            this.Close();

        }

        private void CheckAppointments(NotificationRepository notificationStorage)
        {
            if (room.roomPurpose.Name.Equals("Ordinacija"))
            {
                CheckExaminations(notificationStorage);
            }
            else if (room.roomPurpose.Name.Equals("Operaciona sala"))
            {
                CheckOperations(notificationStorage);
            }
        }

        private void CheckOperations(NotificationRepository notificationStorage)
        {
            foreach (Operation op in operations)
            {
                if (op.Room.Id == room.Id)
                {
                    if (((operation.Date <= op.Date) && (op.Date <= operation.endTime)) ||
                        ((operation.Date <= op.endTime) && (op.endTime <= operation.endTime)))
                    {
                        string contentOfNotification = "Prostorija " + " " + room.Id + " se renovira." + "\n" +
                                                       "Potrebno je pomeranje zakazanog termina";
                        Notification notification = new Notification
                        {
                            Title = "Potrebno pomeranje termina",
                            Content = contentOfNotification,
                            notificationType = NotificationType.secretory,
                            Sender = UserType.director
                        };
                        notifications.Add(notification);
                        notificationStorage.SaveToFile(notifications, "NotificationsFileStorage.json");
                    }
                }
            }
        }

        private void CheckExaminations(NotificationRepository notificationStorage)
        {
            foreach (Examination ex in examinations)
            {
                if (ex.Room.Id == room.Id)
                {
                    if (ex.Date >= operation.Date && ex.Date <= operation.endTime)
                    {
                        string exInfo = ex.Date + "\n" + ex.Patient.Name + " " + ex.Patient.Surname + "\n" + ex.Doctor.Name +
                                        " " + ex.Doctor.Surname;
                        string contentOfNotification = "Prostorija " + " " + room.Id + " se renovira." + "\n" +
                                                       "Potrebno je pomeranje zakazanog termina" + "\n" + exInfo;
                        Notification notification = new Notification
                        {
                            Title = "Potrebno pomeranje termina",
                            Content = contentOfNotification,
                            notificationType = NotificationType.secretory,
                            Sender = UserType.director
                        };
                        notifications.Add(notification);
                        notificationStorage.SaveToFile(notifications, "NotificationsFileStorage.json");
                    }
                }
            }
        }
    }
}
