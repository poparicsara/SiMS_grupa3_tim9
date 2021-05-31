using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Model;
using System.Collections.ObjectModel;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for GuestUserAccount.xaml
    /// </summary>
    public partial class GuestUserAccount : Window
    {
        private GuestUser guestUser = new GuestUser();
        private object sender1 = new object();
        private GuestUserService guestUserService = new GuestUserService();

        public GuestUserAccount(object sender)
        {
            InitializeComponent();
            this.sender1 = sender;
        }

        private void cancelGuest(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            guestUser.SystemName = systemName.Text;
            guestUser.InjuryDescription = injury.Text;

            guestUserService.AddGuestUser(guestUser);

            openAppropriateWindow();
        }

        private void openAppropriateWindow()
        {
            if (sender1.ToString().Equals("System.Windows.Controls.Button: Kreiraj guest nalog"))
            {
                GuestUserListWindow gulw = new GuestUserListWindow();
                gulw.Show();
                this.Close();
            }
            else if (sender1.ToString().Equals("System.Windows.Controls.Button: Prikaži opcije za pregled"))
            {
                AddUrgentExamination aue = new AddUrgentExamination();
                aue.Show();
                this.Close();
            }
            else
            {
                AddUrgentOperationWindow auow = new AddUrgentOperationWindow();
                auow.Show();
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }
    }
}