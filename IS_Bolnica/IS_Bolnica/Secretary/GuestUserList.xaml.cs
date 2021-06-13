
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class GuestUserList : Page
    {
        private Page prevoiusPage;
        private GuestUserService guestUserService = new GuestUserService();
        private GuestUser guestUser = new GuestUser();
        public List<GuestUser> GuestUsers { get; set; }
        public List<GuestUser> DeletedUsers { get; set; }

        public GuestUserList(Page prevoiusPage)
        {
            InitializeComponent();
            this.DataContext = this;
            this.prevoiusPage = prevoiusPage;
            GuestUsers = guestUserService.GetGuestUsers();
            guestUsersGrid.ItemsSource = guestUserService.GetGuestUsers();
            DeletedUsers = new List<GuestUser>();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            AddGuestUser agu = new AddGuestUser(this);
            this.NavigationService.Navigate(agu);
        }

        private void deleteGuestAccount(object sender, RoutedEventArgs e)
        {
            int i = guestUsersGrid.SelectedIndex;

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
                        GuestUserList gul = new GuestUserList(this);
                        this.NavigationService.Navigate(gul);

                        break;
                    case MessageBoxResult.No:
                        return;
                        
                }
            }
        }

        private void DataGrid_PreviewMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void Button_DragOver(object sender, DragEventArgs e)
        {

        }

        private void Button_Drop(object sender, DragEventArgs e)
        {

        }

        private void pretraziBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var filtered = guestUserService.GetSearchedGuests(pretraziBox.Text.ToLower());
            guestUsersGrid.ItemsSource = filtered;
        }
    }
}
