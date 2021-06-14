using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class Options : Page
    {
        private Page prevoiusPage;
        public Options(Page prevoiusPage)
        {
            InitializeComponent();
            this.prevoiusPage = prevoiusPage;
            if (Properties.Settings.Default.ColorMode == "Black")
            {
                darkBtn.IsChecked = true;
            }
            else
            {
                lightBtn.IsChecked = true;
            }
        }

        private void Black_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "Black";
            Properties.Settings.Default.Save();
        }

        private void Light_mode_checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.ColorMode = "White";
            Properties.Settings.Default.Save();
        }

        private void Button_clicked(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }

        private void LanguageBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LanguageBox.SelectedIndex == 0)
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            else
            {
                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-RS");
            }
        }
    }
}
