using System;
using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class AllergenManipulation : Page
    {
        private Page previousPage;

        public AllergenManipulation(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void EditAllergens(object sender, RoutedEventArgs e)
        {

        }

        private void CancelEditingAllergens(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
