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
using IS_Bolnica.GUI.Secretary.View;
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    public partial class AddVacation : Page
    {
        private Page previousPage;
        private DoctorService doctorService = new DoctorService();
        private Vacation vacation = new Vacation();

        public AddVacation(Page previousPage)
        {
            InitializeComponent();
            this.previousPage = previousPage;
        }

        private void addVacation(object sender, RoutedEventArgs e)
        {
            if (!isAllFilled()) return;

            vacation.DoctorsId = idDoctorBox.Text;
            vacation.VacationStartDate = (DateTime)startDateBox.SelectedDate;
            vacation.VacationEndDate = (DateTime) endDateBox.SelectedDate;

            doctorService.AddVacation(vacation);

            DoctorList dl = new DoctorList(this);
            this.NavigationService.Navigate(dl);

        }

        private bool isAllFilled()
        {
            if (idDoctorBox.Text == "" || startDateBox.SelectedDate == null || endDateBox.SelectedDate == null)
            {
                MessageBox.Show("Morate da popunite sva polja!");
                return false;
            }

            return true;
        }

        private void cancelAddingVacation(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(previousPage);
        }
    }
}
