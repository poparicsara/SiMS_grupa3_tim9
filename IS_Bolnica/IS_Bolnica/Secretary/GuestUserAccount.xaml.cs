﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using System.Collections.ObjectModel;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for GuestUserAccount.xaml
    /// </summary>
    public partial class GuestUserAccount : Window
    {
        private GuestUser guest = new GuestUser();
        private GuestUsersFileStorage storage = new GuestUsersFileStorage();

        public GuestUserAccount()
        {
            InitializeComponent();
        }

        private void cancelGuest(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            guest.SystemName = systemName.Text;
            guest.InjuryDescription = injury.Text;

            ObservableCollection<GuestUser> lista = storage.loadFromFile("GuestUsersFile.json");
            lista.Add(guest);
            storage.saveToFile(lista, "GuestUsersFile.json");

            SekretarWindow sw = new SekretarWindow();
            sw.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
        }
    }
}