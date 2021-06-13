using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Secretary.ViewModel;
using IS_Bolnica.Secretary;

namespace IS_Bolnica.GUI.Secretary.View
{
    public partial class SecretaryProfile : Page
    {
        public SecretaryProfile(string username, SekretarWindow window)
        {
            InitializeComponent();
            DataContext = new SecretaryProfileVM(username, window);
        }


        /*private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void Logout_Clicked(object sender, RoutedEventArgs e)
        {
            
        }*/
    }
}
