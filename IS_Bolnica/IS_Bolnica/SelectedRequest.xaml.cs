﻿using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
    public partial class SelectedRequest : Window
    {
        private Request selectedRequest;
        private int selectedId;
        public SelectedRequest(Request selected)
        {
            InitializeComponent();

            selectedRequest = selected;
            Debug.WriteLine(selectedRequest.Content);

            string[] content = selectedRequest.Content.Split('|');

            selectedId = (int)Int64.Parse(content[0]);
            idBox.Text = content[0];
            nameBox.Text = content[1];
            replacementBox.Text = content[2];
            producerBox.Text = content[3];
            ingredientBox.Text = content[4];

            if(selected.Title.Equals("Dodavanje leka u bazu"))
            {
                deleteButton.IsEnabled = false;
            }
            else
            {
                sentToEditButton.IsEnabled = false;
                acceptMedButton.IsEnabled = false;
            }
            
        }

        private void AcceptMedicamentButton(object sender, RoutedEventArgs e)
        {
            MedicamentRepository medStorage = new MedicamentRepository();
            List<Medicament> meds = medStorage.GetMedicaments();

            foreach (Medicament med in meds)
            {
                if(med.Id == (int)Int64.Parse(idBox.Text))
                {
                    med.Status = MedicamentStatus.approved;
                }
            }

            medStorage.SaveToFile(meds);

            DeleteRequest();
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
            
        }

        private void SentToEditButton(object sender, RoutedEventArgs e)
        {
            Notification notification = new Notification();

            notification.Title = "Izmena zahteva za novi lek";
            string temp = selectedRequest.Content.Replace('|', '\n');
            temp += "\n";
            notification.Content = temp + "\n" + responceBox.Text.ToUpper();
            notification.notificationType = NotificationType.director;
            notification.Sender = UserType.doctor;

            NotificationRepository notificationStorage = new NotificationRepository();
            List<Notification> notifications = notificationStorage.LoadFromFile("NotificationsFileStorage.json");

            notifications.Add(notification);

            notificationStorage.SaveToFile(notifications, "NotificationsFileStorage.json");

            DeleteRequest();
            RequestWindow requestWindow = new RequestWindow();
            requestWindow.Show();
            this.Close();
            
        }

        private void ConfirmDeletingButton(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da dozvolite brisanje leka",
                "Brisanje leka", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    MedicamentRepository medStorage = new MedicamentRepository();
                    List<Medicament> meds = medStorage.GetMedicaments();
                    int index = 0;
                    foreach(Medicament med in meds)
                    {
                        if(med.Id == selectedId)
                        {
                        break;
                        }
                        index++;
                    }
                    meds.RemoveAt(index);
                    medStorage.SaveToFile(meds);
                    break;
                case MessageBoxResult.No:
                    break;
            }
            DeleteRequest();
            this.Close();            
            
        }

        private void DeleteRequest()
        {
            RequestRepository requestStorage = new RequestRepository();
            List<Request> requests = requestStorage.GetRequests();
            int i = 0;
            foreach (Request r in requests)
            {
                if (r.Title.Equals(selectedRequest.Title) && r.Content.Equals(selectedRequest.Content))
                {
                    break;
                }
                i++;
            }
            requests.RemoveAt(i);
            requestStorage.SaveToFile(requests);
        }
    }
}
