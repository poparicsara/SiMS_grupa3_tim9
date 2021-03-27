using System.Windows;

namespace IS_Bolnica
{
 
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonUpravnikClicked (object sender, RoutedEventArgs e)
        {
            UpravnikWindow uw = new UpravnikWindow();
            uw.Show();
            this.Close();

        }

        private void ButtonSekretarClicked(object sender, RoutedEventArgs e)
        {
            SekretarWindow sw = new SekretarWindow();
            sw.Show();
            this.Close();

        }
    }
}
