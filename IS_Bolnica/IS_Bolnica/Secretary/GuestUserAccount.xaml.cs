using System;
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
        private object sender1 = new object();

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
            guest.SystemName = systemName.Text;
            guest.InjuryDescription = injury.Text;

            List<GuestUser> lista = storage.loadFromFile("GuestUsersFile.json");
            lista.Add(guest);
            storage.saveToFile(lista, "GuestUsersFile.json");

            if(sender1.ToString().Equals("System.Windows.Controls.Button: Kreiraj guest nalog"))
            {
                GuestUserListWindow gulw = new GuestUserListWindow();
                gulw.Show();
                this.Close();
            } else if (sender1.ToString().Equals("System.Windows.Controls.Button: Prikaži opcije za pregled"))
            {
                AddUrgentExamination aue = new AddUrgentExamination();
                aue.Show();
                this.Close();
            } else
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