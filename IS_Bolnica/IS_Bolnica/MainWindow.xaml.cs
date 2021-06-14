using Model;
using System.Windows;
using System.Collections.ObjectModel;
using IS_Bolnica.Model;
using System.Collections.Generic;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {
        private UserRepository storage = new UserRepository();
        private PatientRepository patientStorage = new PatientRepository();
        private List<User> users = new List<User>();
        private List<Patient> patients = new List<Patient>();
        private User user = new User();
        private List<User> loggedUsers = new List<User>();


        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonUpravnikClicked(object sender, RoutedEventArgs e)
        {
            DirectorProfileWindow profileWindow = new DirectorProfileWindow("0601111", "sara");
            profileWindow.Show();
        }

        private void doctorButtonClicked(object sender, RoutedEventArgs e)
        {
            //DoctorWindow doctorWindow = new DoctorWindow();
            //doctorWindow.Show();
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
        }

        //private void PatientButtonClicked(object sender, RoutedEventArgs e)
        //{
        //    PatientWindow pw = new PatientWindow();
        //    pw.Show();

        //}

        private void ButtonSekretarCLicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow("");
            sw.Show();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            users = storage.LoadFromFile("UsersFileStorage.json");
            patients = patientStorage.GetAll();

            string username = usernameBox.Text;
            string password = passwordBox.Password.ToString();

            foreach (User user in users)
            {
                if (user.Username.Equals(username) && user.Password.Equals(password))
                {
                    switch (user.UserType)
                    {
                        case UserType.patient:
                            foreach(Patient patient in patients)
                            {
                                if(patient.Username.Equals(user.Username) && patient.Password.Equals(user.Password))
                                {
                                    PatientWindow pw = new PatientWindow(username);
                                    pw.Show();
                                    break;
                                }
                            }
                            break;
                        case UserType.doctor:

                            loggedUsers.Add(user); 
                            storage.SaveToFile(loggedUsers, "loggedUsers.json");
                            //DoctorWindow doctorWindow = new DoctorWindow();
                            //doctorWindow.Show();
                            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
                            doctorStartWindow.Show();
                            this.Close();

                            break;
                        case UserType.director:
                            DirectorProfileWindow profileWindow = new DirectorProfileWindow("0601111", "sara");
                            profileWindow.Show();
                            break;
                        case UserType.secretary:
                            SekretarWindow sw = new SekretarWindow(username);
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
