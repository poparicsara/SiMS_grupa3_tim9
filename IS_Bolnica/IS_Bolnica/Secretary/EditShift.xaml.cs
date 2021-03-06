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
    public partial class EditShift : Page
    {
        private Page prevoiusPage;
        private DoctorService doctorService = new DoctorService();
        private Shift shift = new Shift();
        public EditShift(Page prevoiusPage)
        {
            InitializeComponent();
            this.prevoiusPage = prevoiusPage;
        }

        private bool isAllFilled()
        {
            if (shiftBox.SelectedIndex == -1 || dateStartBox.SelectedDate == null || dateEndBox.SelectedDate == null)
            {
                MessageBox.Show("Morate da popunite sva polja!");
                return false;
            }

            return true;
        }

        private void addShift(object sender, RoutedEventArgs e)
        {
            if (!isAllFilled()) return;
            int startTime = 0;
            int endTime = 0;
            if (shiftBox.SelectedIndex == 0)
            {
                shift.ShiftType = ShiftType.day;
                startTime = 6;
                endTime = 18;

            }
            else
            {
                shift.ShiftType = ShiftType.night;
                startTime = 18;
                endTime = 6;
            }

            DateTime dateStart = (DateTime) dateStartBox.SelectedDate;
            shift.ShiftStartDate = new DateTime ( dateStart.Year, dateStart.Month, dateStart.Day, startTime, 0, 0);
            DateTime dateEnd = (DateTime) dateEndBox.SelectedDate;
            shift.ShiftEndDate = new DateTime(dateEnd.Year, dateEnd.Month, dateEnd.Day, endTime, 0, 0);
            shift.DoctorsId = idDoctorBox.Text;

            doctorService.AddShift(shift);

            DoctorList dl = new DoctorList(this);
            this.NavigationService.Navigate(dl);

        }

        private void cancelAddingShift(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(prevoiusPage);
        }
    }
}
