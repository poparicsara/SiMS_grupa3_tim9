using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for ReportForm.xaml
    /// </summary>
    public partial class ReportForm : Page
    {
        private Page previousPage;

        public ReportForm(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }
    }
}
