﻿using Model;
using System.Windows;
using System.Collections.ObjectModel;
using IS_Bolnica.Model;
using System.Collections.Generic;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {
        private UsersFileStorage storage = new UsersFileStorage();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        private List<User> users = new List<User>();
        private List<Patient> patients = new List<Patient>();
        private User user = new User();
        private List<User> loggedUsers = new List<User>();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonUpravnikClicked(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            UpravnikWindow uw = new UpravnikWindow(director);
            uw.Show();
        }

        private void doctorButtonClicked(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
        }

        //private void PatientButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    PatientWindow pw = new PatientWindow();
        //    pw.Show();

        //}

        private void ButtonSekretarCLicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = storage.loadFromFile("UsersFileStorage.json");
            patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            
            string username = usernameBox.Text;
            string password = passwordBox.Password.ToString();

            foreach (User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    switch (user.UserType)
                    {
                        case UserType.patient:
                            foreach(Patient patient in patients)
                            {
                                if(patient.Username.Equals(user.Username) && patient.Password.Equals(user.Password))
                                {
                                    PatientWindow pw = new PatientWindow(patient);
                                    pw.Show();
                                    break;
                                }
                            }
                            break;
                        case UserType.doctor:

                            loggedUsers.Add(user);
                            storage.saveToFile(loggedUsers, "loggedUsers.json");
                            DoctorWindow doctorWindow = new DoctorWindow();
                            doctorWindow.Show();
                            this.Close();

                            break;
                        case UserType.director:
                            Director director = new Director();
                            UpravnikWindow uw = new UpravnikWindow(director);
                            uw.Show();
                            break;
                        case UserType.secretary:
                            SekretarWindow sw = new SekretarWindow();
                            sw.setProfileInfo(user);
                            sw.Show();
                            break;
                        default:
                            MessageBox.Show("Nepostojeci korisnik!");
                            break;
                    }
                }
            }
        }
    }
}
