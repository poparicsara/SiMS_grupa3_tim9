﻿using System;
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

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for SekretarWindow.xaml
    /// </summary>
    public partial class SekretarWindow : Window
    {
        public SekretarWindow()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            Secretary.AddPatient ap = new Secretary.AddPatient();
            ap.Show();
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            Secretary.EditPatient ep = new Secretary.EditPatient();
            ep.Show();
        }

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount();
            gua.Show();
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete pacijenta?", "Brisanje pacijenta", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
}
