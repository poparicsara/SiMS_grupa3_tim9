using System.Windows;

namespace IS_Bolnica
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Wrap1.Height = mainWindow.Height;
            Wrap1.Width = 250;
        }

        private void ButtonUpravnikClicked(object sender, RoutedEventArgs e)
        {
            Window upravnikWindow = new Window();
            upravnikWindow.Height = mainWindow.Height;
            upravnikWindow.Width = mainWindow.Width;
            upravnikWindow.Show();
            upravnikWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

        }
    }
}
