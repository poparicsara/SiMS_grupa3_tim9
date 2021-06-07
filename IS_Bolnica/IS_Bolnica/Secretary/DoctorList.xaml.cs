using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class DoctorList : Page
    {
        private Page previousPage;
        private DoctorService doctorService = new DoctorService();
        public DoctorList(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
            DoctorListGrid.ItemsSource = doctorService.GetDoctors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void pretraziBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void addVacation(object sender, RoutedEventArgs e)
        {
            AddVacation av = new AddVacation(this);
            this.NavigationService.Navigate(av);
        }

        private void addShift(object sender, RoutedEventArgs e)
        {
            EditShift es = new EditShift(this);
            this.NavigationService.Navigate(es);
        }
    }
}
