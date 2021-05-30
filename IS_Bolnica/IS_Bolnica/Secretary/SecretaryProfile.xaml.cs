using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Model;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for SecretaryProfile.xaml
    /// </summary>
    public partial class SecretaryProfile : Page
    {
        public SecretaryProfile()
        {
            InitializeComponent();
            //setProfileInfo(user);
        }

        private void ActionBarOpen(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        public void setProfileInfo(User user)
        {
            name.Text = user.Name;
            surname.Text = user.Surname;
            username.Text = user.Username;
            dateOfBirth.Text = Convert.ToString(user.DateOfBirth.Date);
            iniciallyPassword.Text = user.Password;
            id.Text = user.Id.ToString();
            phone.Text = user.Phone.ToString();
            email.Text = user.Email;
            adress.Text = user.Address.Street + " "
                                              + user.Address.NumberOfBuilding + "/"
                                              + user.Address.Floor + "/"
                                              + user.Address.Apartment;
            city.Text = user.Address.City.name + " "
                                               + Convert.ToString(user.Address.City.postalCode);
            country.Text = user.Address.City.Country.name;
        }
    }
}
