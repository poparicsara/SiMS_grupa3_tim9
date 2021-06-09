using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class AddGuestUser : Page
    {
        private Page prevoiusPage;
        private GuestUser guestUser = new GuestUser();
        private object sender1 = new object();
        private GuestUserService guestUserService = new GuestUserService();

        public AddGuestUser(Page prevoiusPage)
        {
            InitializeComponent();
            this.prevoiusPage = prevoiusPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }

        private void cancelGuest(object sender, RoutedEventArgs e)
        {
            GuestUserList gul = new GuestUserList(this);
            this.NavigationService.Navigate(gul);
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            if (systemName.Text == "" || injury.Text == "")
            {
                MessageBox.Show("Morate da popunite sva polja!");
                return;
            }

            guestUser.SystemName = systemName.Text;
            guestUser.InjuryDescription = injury.Text;

            guestUserService.AddGuestUser(guestUser);

            GuestUserList gul = new GuestUserList(this);
            this.NavigationService.Navigate(gul);
        }
    }
}
