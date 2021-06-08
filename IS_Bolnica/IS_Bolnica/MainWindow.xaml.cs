﻿using Model;
using System.Windows;
using System.Collections.ObjectModel;
using IS_Bolnica.Model;
using System.Collections.Generic;
using System.IO;
using IS_Bolnica.DemoMode;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {
        private UserRepository storage = new UserRepository();
        private PatientRepository patientStorage = new PatientRepository();
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
            DirectorProfileWindow dw = new DirectorProfileWindow("0601234567", "ivanivanovic@gmail.com");
            dw.Show();
        }

        private void doctorButtonClicked(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
        }

        //private void PatientButtonClicked(object sender, RoutedEventArgs eč
        //{
        //    PatientWindow pw = new PatientWindow(č;
        //    pw.Show(č;

        //}

        private void ButtonSekretarCLicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*users = storage.LoadFromFile("UserRepository.json");
            patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");
            
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
                                    PatientWindow pw = new PatientWindow(username, true);
                                    pw.Show();
                                    break;
                                }
                            }
                            break;
                        case UserType.doctor:

                            loggedUsers.Add(user);
                            storage.SaveToFile(loggedUsers, "loggedUsers.json");
                            DoctorWindow doctorWindow = new DoctorWindow();
                            doctorWindow.Show();
                            this.Close();

                            break;
                        case UserType.director:
                            DirectorProfileWindow dw = new DirectorProfileWindow("0601234567", "ivanivanovic@gmail.com");
                            dw.Show();
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
            }*/

            string username = usernameBox.Text;
            string password = passwordBox.Password.ToString();
            if (!username.Equals("Sara"))
            {
                MessageBox.Show("Navedeno korisničko ima ne postoji!");
            }
            else if (!password.Equals("ftn"))
            {
                MessageBox.Show("Pogrešna lozinka!");
            }
            else
            {
                DirectorProfileWindow dw = new DirectorProfileWindow("0601234567", "ivanivanovic@gmail.com");
                dw.Show();
            }
        }

        private void DemoButtonClicked(object sender, RoutedEventArgs e)
        {
            DemoRoomWindow rw = new DemoRoomWindow();
            rw.Show();
        }
    }
}
