using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Secretary.View;
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.Secretary
{
    public partial class SelectedDoctor : Page
    {
        private Doctor doctor = new Doctor();
        private DoctorService doctorService = new DoctorService();

        public SelectedDoctor(Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;
            ShiftList.ItemsSource = doctor.Shifts;
            VacationList.ItemsSource = doctor.Vacations;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DoctorList dl = new DoctorList(new ActionBar());
            this.NavigationService.Navigate(dl);
        }

        private void DeleteShift(object sender, RoutedEventArgs e)
        {
            int i = ShiftList.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Niste obeležili smenu koju želite da obrišete!");
            }
            else
            {
                Shift shift = (Shift) ShiftList.SelectedItem;
                doctorService.DeleteShift(shift);
                SelectedDoctor sd = new SelectedDoctor(this.doctor);
                sd.doctorNameSurnameLabel.Content = this.doctor.Name + " " + this.doctor.Surname;
                this.NavigationService.Navigate(sd);

            }
        }

        private void DeleteVacation(object sender, RoutedEventArgs e)
        {
            int i = VacationList.SelectedIndex;
            if (i == -1)
            {
                MessageBox.Show("Niste obeležili odmor koji želite da obrišete!");
            }
            else
            {
                Vacation vacation = (Vacation)VacationList.SelectedItem;
                doctorService.DeleteVacation(vacation);
                SelectedDoctor sd = new SelectedDoctor(doctor);
                sd.doctorNameSurnameLabel.Content = this.doctor.Name + " " + this.doctor.Surname;
                this.NavigationService.Navigate(sd);

            }
        }
    }
}
