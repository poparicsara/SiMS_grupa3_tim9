using System;
using System.Windows;
using System.Windows.Controls;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Model;

namespace IS_Bolnica
{
    public partial class SekretarWindow : Window, INotifyPropertyChanged
    {
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private Patient pacijent;

        public ObservableCollection<Patient> Pacijenti {
            get; set;
        }

        private int colNum = 0;

        public SekretarWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pacijenti = new ObservableCollection<Patient>();
            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
        }

        private void generateColumns(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            colNum++;
            if(colNum == 3)
            {
                e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
