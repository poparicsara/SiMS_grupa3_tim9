﻿using Model;
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

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditOperationWindow.xaml
    /// </summary>
    public partial class EditOperationWindow : Window
    {
        public List<RoomRecord> Rooms
        {
            get;
            set;
        }
        public List<int> RoomNums { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        private Operation operation = new Operation();
        private Operation oldOperation = new Operation();
        private List<Operation> Operations = new List<Operation>();
        private OperationsFileStorage operationStorage = new OperationsFileStorage();
        private List<Patient> Patients = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();

        public EditOperationWindow(Operation oldOperation)
        {
            InitializeComponent();

            this.oldOperation = oldOperation;

            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            room.ItemsSource = RoomNums;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private bool idExists(List<Patient> patients, string id)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].Id.Equals(id))
                {
                    return true;
                }

            }

            MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            return false;

        }

        private bool isPatientFree(List<Operation> operations, Patient patient, DateTime dateAndTimeStart, DateTime dateAndTimeEnd)
        {
            foreach (Operation operation in operations)
            {
                if (operation.Patient.Id == patient.Id)
                {
                    if (operation.Date <= dateAndTimeStart && dateAndTimeStart <= operation.endTime)
                    {
                        if (operation.Date <= dateAndTimeEnd && dateAndTimeEnd <= operation.endTime)
                        {
                            if (operation.Date >= dateAndTimeStart && operation.endTime <= dateAndTimeEnd)
                            {
                                MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                                return false;
                            }
                            MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                            return false;
                        }
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }

                }

            }

            return true;
        }

        private bool isRoomFree(List<Operation> operations, RoomRecord room, DateTime dateAndTimeStart, DateTime dateAndTimeEnd)
        {
            foreach (Operation operation in operations)
            {
                if (operation.RoomRecord.Id == room.Id)
                {
                    if (operation.Date <= dateAndTimeStart && dateAndTimeStart <= operation.endTime)
                    {
                        if (operation.Date <= dateAndTimeEnd && dateAndTimeEnd <= operation.endTime)
                        {
                            if (operation.Date >= dateAndTimeStart && operation.endTime <= dateAndTimeEnd)
                            {
                                MessageBox.Show("Soba " + room.Id + " je zauzeta u izabranom terminu");
                                return false;
                            }
                            MessageBox.Show("Soba " + room.Id + " je zauzeta u izabranom terminu");
                            return false;
                        }
                        MessageBox.Show("Soba " + room.Id + " je zauzeta u izabranom terminu");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isDoctorFree(List<Operation> operations, Doctor doc, DateTime dateAndTimeStart, DateTime dateAndTimeEnd)
        {
            foreach (Operation operation in operations)
            {
                if (operation.doctor.Name == doc.Name && operation.doctor.Surname == doc.Surname)
                {
                    if (operation.Date <= dateAndTimeStart && dateAndTimeStart <= operation.endTime)
                    {
                        if (operation.Date <= dateAndTimeEnd && dateAndTimeEnd <= operation.endTime)
                        {
                            if (operation.Date >= dateAndTimeStart && operation.endTime <= dateAndTimeEnd)
                            {
                                MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                                return false;
                            }
                            MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                            return false;
                        }
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }

            }
            return true;
        }

        private bool isAvailable(List<Operation> operations, Patient patient, RoomRecord room, Doctor doctor, DateTime dateAndTimeStart, DateTime dateAndTimeEnd)
        {
            if (isPatientFree(operations, patient, dateAndTimeStart, dateAndTimeEnd)
                && isRoomFree(operations, room, dateAndTimeStart, dateAndTimeEnd)
                && isDoctorFree(operations, doctor, dateAndTimeStart, dateAndTimeEnd))
            {
                return true;
            }
            else
            {
                //MessageBox.Show("Ovaj pregled je vec zauzet!");

                return false;
            }

        }

        private void editOperation(object sender, RoutedEventArgs e)
        {
            Operations = operationStorage.loadFromFile("operations.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");

            if (idExists(Patients, patientId.Text))
            {
                string[] doctorNameAndSurname = doctorBox.Text.Split(' ');
                Doctor doctor = new Doctor();
                doctor.Name = doctorNameAndSurname[0];
                doctor.Surname = doctorNameAndSurname[1];
                operation.doctor = doctor;

                for (int i = 0; i < Patients.Count; i++)
                {
                    if (Patients[i].Id.Equals(patientId.Text))
                    {
                        operation.Patient = Patients[i];
                    }
                }

                DateTime datumStart = new DateTime();
                datumStart = (DateTime)date.SelectedDate;
                int satStart = Convert.ToInt32(hourBoxStart.Text);
                int minutStart = Convert.ToInt32(minutesBoxStart.Text);
                operation.Date = new DateTime(datumStart.Year, datumStart.Month, datumStart.Day, satStart, minutStart, 0);

                DateTime datumEnd = new DateTime();
                datumEnd = (DateTime)date.SelectedDate;
                int satEnd = satStart + Convert.ToInt32(hourBoxEnd.Text);
                if (satEnd >= 24)
                {
                    datumEnd.AddDays(1);
                    satEnd = satEnd - 24;
                }
                int minutEnd = minutStart + Convert.ToInt32(minuteBoxEnd.Text);
                if (minutEnd >= 60)
                {
                    satEnd += 1;
                    minutEnd = minutEnd - 60;
                }
                operation.endTime = new DateTime(datumEnd.Year, datumEnd.Month, datumEnd.Day, satEnd, minutEnd, 0);

                operation.RoomRecord = new RoomRecord();
                for (int i = 0; i < Rooms.Count; i++)
                {
                    if (Rooms[i].Id == Convert.ToInt32(room.SelectedItem))
                    {
                        operation.RoomRecord = Rooms[i];
                    }
                }
                

                if (isAvailable(Operations, operation.Patient, operation.RoomRecord, operation.doctor, operation.Date, operation.endTime))
                {
                    Operations.Add(operation);
                    for (int i = 0; i < Operations.Count; i++)
                    {
                        if (Operations[i].Date.Equals(oldOperation.Date)
                            && Operations[i].Patient.Id.Equals(oldOperation.Patient.Id)
                            && Operations[i].endTime.Equals(oldOperation.endTime)
                            && Operations[i].RoomRecord.Id.Equals(oldOperation.RoomRecord.Id))
                        {
                            Operations.RemoveAt(i);
                        }
                    }
                    operationStorage.saveToFile(Operations, "operations.json");
                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }

            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }

        private void cancelEditingOperation(object sender, RoutedEventArgs e)
        {
            Secretary.OperationListWindow olw = new Secretary.OperationListWindow();
            olw.Show();
            this.Close();
        }
    }
}
