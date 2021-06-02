using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class Options : Page
    {
        public Options()
        {
            InitializeComponent();
        }

        private void Black_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";
            Properties.Settings.Default.Save();
            darkBtn.IsChecked = true;
        }

        private void Light_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "White";
            Properties.Settings.Default.Save();
            lightBtn.IsChecked = true;
        }

        private void Button_clicked(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void LanguageBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageBox.SelectedIndex == 0)
                Properties.Settings.Default.languageCode = "en-US";
            else
            {
                Properties.Settings.Default.languageCode = "srp-RS";
            }
            Properties.Settings.Default.Save();
        }
    }
}
