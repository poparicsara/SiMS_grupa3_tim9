using Model;
using System.Windows;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {
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

        private void PatientButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow pw = new PatientWindow();
            pw.Show(); 
            
        }

        private void ButtonSekretarCLicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();

        }
    }
}
