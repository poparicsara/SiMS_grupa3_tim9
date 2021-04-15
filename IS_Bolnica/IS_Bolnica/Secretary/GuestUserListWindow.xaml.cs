using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public partial class GuestUserListWindow : Window, INotifyPropertyChanged
    {
        private GuestUsersFileStorage storage = new GuestUsersFileStorage();
        public ObservableCollection<GuestUser> GuestKorisnici
        {
            get; set;
        }
        public GuestUserListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            GuestKorisnici = new ObservableCollection<GuestUser>();
            GuestKorisnici = storage.loadFromFile("GuestUsersFile.json");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deleteGuestAccount(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = GuestUsers.SelectedIndex;

            GuestUser guestKorisnik = new GuestUser();
            guestKorisnik = (GuestUser)GuestUsers.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose account which you want to delete!");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete nalog?", "Brisanje pacijenta", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        GuestKorisnici = storage.loadFromFile("GuestUsersFile.json");
                        for (int k = 0; k < GuestKorisnici.Count; k++)
                        {
                            if (guestKorisnik.SystemName.Equals(GuestKorisnici[k].SystemName))
                            {
                                GuestKorisnici.RemoveAt(k);
                            }
                        }
                        storage.saveToFile(GuestKorisnici, "GuestUsersFile.json");
                        this.Close();


                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                }
            }
        }

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount();
            this.Close();
            gua.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}