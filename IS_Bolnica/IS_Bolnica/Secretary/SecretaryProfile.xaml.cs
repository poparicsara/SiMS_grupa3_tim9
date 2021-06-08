using System;
using System.Windows;
using System.Windows.Controls;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class SecretaryProfile : Page
    {
        public SecretaryProfile()
        {
            InitializeComponent();
            //setProfileInfo(user);
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
