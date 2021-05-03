﻿using Model;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for AddUrgentOperationWindow.xaml
    /// </summary>
    public partial class AddUrgentOperationWindow : Window
    {
        private Specialization specialization = new Specialization();
        public List<String> Specializations { get; set; } = new List<String>();
        private List<Specialization> specializations;
        private Operation operation;
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        private List<Patient> patients = new List<Patient>();
        private Patient patient = new Patient();
        private GuestUsersFileStorage guestStorage = new GuestUsersFileStorage();
        private List<GuestUser> guestUsers = new List<GuestUser>();
        private GuestUser guestUser = new GuestUser();

        public AddUrgentOperationWindow()
        {
            InitializeComponent();
            specializations = specialization.getSpecializations();
            foreach (Specialization spec in specializations)
            {
                Specializations.Add(spec.Name);
            }
            specializationBox.ItemsSource = Specializations;
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            GuestUserAccount gua = new GuestUserAccount(sender);
            gua.Show();
            this.Close();
        }

        private Patient findPatient(string id)
        {
            Patient patien = new Patient();
            patients = patientStorage.loadFromFile("PatientRecordFileStorgae.json");

            foreach (Patient pat in patients)
            {
                if (pat.Id.Equals(id))
                {
                    patien = pat;
                }
            }

            return patien;

        }

        private GuestUser findGuest(string systemName)
        {
            GuestUser guest = new GuestUser();
            guestUsers = guestStorage.loadFromFile("GuestUsersFile.json");

            foreach(GuestUser gUser in guestUsers)
            {
                if(gUser.SystemName.Equals(systemName))
                {
                    guest = gUser;
                }
            }

            return guest;
        }

        private void findSpecialization(string spec)
        {
            foreach(Specialization s in specializations)
            {
                if(s.Name.Equals(spec))
                {
                    specialization = s;
                }
            }
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if(patientIdBox.Text != null)
            {
                patient = findPatient(patientIdBox.Text);
            } else if(patientIdBox.Text == null && patientIdBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli id pacijenta");
                return;
            } else if(systemNameBox.Text != null)
            {
                guestUser = findGuest(systemNameBox.Text);
            } else if(systemNameBox.Text == null && systemNameBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli sistemsko ime guest korisnika");
                return;
            }

            int duration = Convert.ToInt32(hourBox.Text) * 60 + Convert.ToInt32(minuteBox);

            operation = new Operation { DurationInMins = duration, GuestUser = guestUser, Patient = patient };
            findSpecialization(specializationBox.SelectedItem.ToString());

            UrgentOperationOptionsWindow uoow = new UrgentOperationOptionsWindow(operation, specialization);
            uoow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void existableRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = true;
            systemNameBox.IsEnabled = false;
        }

        private void guestRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = false;
            systemNameBox.IsEnabled = true;
        }
    }
}
