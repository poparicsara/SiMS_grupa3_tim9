
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class GuestUserList : Page
    {
        private GuestUserService guestUserService = new GuestUserService();
        private GuestUser guestUser = new GuestUser();

        public GuestUserList()
        {
            InitializeComponent();
            this.DataContext = this;
            guestUsersGrid.ItemsSource = guestUserService.GetGuestUsers();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void createGuestAccount(object sender, RoutedEventArgs e)
        {
            AddGuestUser agu = new AddGuestUser();
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
                        GuestUserList gul = new GuestUserList();
                        this.NavigationService.Navigate(gul);

                        break;
                    case MessageBoxResult.No:
                        return;
                        break;
                }
            }
        }
    }
}
