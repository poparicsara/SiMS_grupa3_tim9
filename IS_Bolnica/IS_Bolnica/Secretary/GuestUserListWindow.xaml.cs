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
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class GuestUserListWindow : Window, INotifyPropertyChanged
    {
        private GuestUserService guestUserService = new GuestUserService();
        private GuestUser guestUser = new GuestUser();
        public GuestUserListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            guestUsersGrid.ItemsSource = guestUserService.GetGuestUsers();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void deleteGuestAccount(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = guestUsersGrid.SelectedIndex;
            
            guestUser = (GuestUser)guestUsersGrid.SelectedItem;

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
                        guestUserService.DeleteGuestUser(guestUser);
                        this.Close();
                        GuestUserListWindow gulw = new GuestUserListWindow();
                        gulw.Show();

                        break;
                    case MessageBoxResult.No:
                        return;
                        break;
                }
            }
        }

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            Secretary.GuestUserAccount gua = new Secretary.GuestUserAccount(sender);
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