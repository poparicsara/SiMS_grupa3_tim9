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
    public partial class EditShift : Page
    {
        private DoctorService doctorService = new DoctorService();
        private Shift shift = new Shift();
        public EditShift()
        {
            InitializeComponent();
        }

        private void addShift(object sender, RoutedEventArgs e)
        {
            if (shiftBox.SelectedIndex == 0)
            {
                shift.ShiftType = ShiftType.day;
            }
            else
            {
                shift.ShiftType = ShiftType.night;
            }

            shift.ShiftStartDate = (DateTime)dateStartBox.SelectedDate;
            shift.ShiftEndDate = (DateTime) dateEndBox.SelectedDate;
            shift.DoctorsId = idDoctorBox.Text;

            doctorService.AddShift(shift);

            DoctorList dl = new DoctorList();
            this.NavigationService.Navigate(dl);

        }

        private void cancelAddingShift(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }
    }
}
