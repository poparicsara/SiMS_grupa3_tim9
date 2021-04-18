using Model;
using System.Windows;
using System.Collections.ObjectModel;
using IS_Bolnica.Model;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {

        private UsersFileStorage storage = new UsersFileStorage();
        private ObservableCollection<User> users = new ObservableCollection<User>();
        private User user = new User();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonUpravnikClicked(object sender, RoutedEventArgs e)
        {
            Director director = new Director();
            UpravnikWindow uw = new UpravnikWindow(director);
            uw.Show();
        }

        private void doctorButtonClicked(object sender, RoutedEventArgs e)
        {
            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.Show();
        }

        //private void PatientButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    PatientWindow pw = new PatientWindow();
        //    pw.Show();

        //}

        private void ButtonSekretarCLicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = storage.loadFromFile("UsersFileStorage.json");
            string username = usernameBox.Text;
            string password = passwordBox.Text;

            foreach (User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    switch (user.UserType)
                    {
                        case UserType.patient:
                            PatientWindow pw = new PatientWindow(username);
                            pw.Show();
                            break;
                        case UserType.doctor:
                            DoctorWindow doctorWindow = new DoctorWindow();
                            doctorWindow.Show();
                            break;
                        case UserType.director:
                            Director director = new Director();
                            UpravnikWindow uw = new UpravnikWindow(director);
                            uw.Show();
                            break;
                        case UserType.secretary:
                            SekretarWindow sw = new SekretarWindow();
                            sw.Show();
                            break;
                        default:
                            MessageBox.Show("Nepostojeci korisnik!");
                            break;
                    }
                }
            }
        }
    }
}
