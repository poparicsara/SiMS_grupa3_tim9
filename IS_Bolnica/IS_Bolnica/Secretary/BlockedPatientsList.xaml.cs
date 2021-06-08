using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class BlockedPatientsList : Page
    {
        private Page previousPage;

        public BlockedPatientsList(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Unblock_Patient_clicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
