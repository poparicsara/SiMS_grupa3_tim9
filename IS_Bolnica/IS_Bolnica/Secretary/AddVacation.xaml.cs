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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddVacation : Page
    {
        private DoctorService doctorService = new DoctorService();
        private Vacation vacation = new Vacation();

        public AddVacation()
        {
            InitializeComponent();
        }

        private void addVacation(object sender, RoutedEventArgs e)
        {
            vacation.DoctorsId = idDoctorBox.Text;
            vacation.VacationStartDate = (DateTime)startDateBox.SelectedDate;
            vacation.VacationEndDate = (DateTime) endDateBox.SelectedDate;

            doctorService.AddVacation(vacation);

            DoctorList dl = new DoctorList();
            this.NavigationService.Navigate(dl);

        }

        private void cancelAddingVacation(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }
    }
}
