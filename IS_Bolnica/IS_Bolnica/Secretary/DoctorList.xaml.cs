using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class DoctorList : Page
    {
        private DoctorService doctorService = new DoctorService();
        public DoctorList()
        {
            InitializeComponent();
            DoctorListGrid.ItemsSource = doctorService.GetDoctors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void pretraziBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }

        private void addVacation(object sender, RoutedEventArgs e)
        {
            AddVacation av = new AddVacation();
            this.NavigationService.Navigate(av);
        }

        private void addShift(object sender, RoutedEventArgs e)
        {
            EditShift es = new EditShift();
            this.NavigationService.Navigate(es);
        }
    }
}
