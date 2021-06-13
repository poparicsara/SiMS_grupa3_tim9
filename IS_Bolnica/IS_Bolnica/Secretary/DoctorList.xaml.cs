using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using IS_Bolnica.GUI.Secretary.View;
using IS_Bolnica.Patterns;
using IS_Bolnica.Services;
using Model;

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
            DoctorListGrid.ItemsSource = doctorService.GetAllDoctors();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void pretraziBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //var filtered = doctorService.GetSearchedDoctors(pretraziBox.Text.ToLower());
            //DoctorListGrid.ItemsSource = filtered;
            SearchGridTemplate<Doctor> doctors = new SearchDoctors();
            var filtered = doctors.GetSearchedEntities(pretraziBox.Text.ToLower());
            DoctorListGrid.ItemsSource = filtered;
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

        private void DoctorListGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(DoctorListGrid.SelectedIndex == -1) return;
            Doctor doctor = (Doctor) DoctorListGrid.SelectedItem;
            SelectedDoctor sd = new SelectedDoctor(doctor);
            sd.doctorNameSurnameLabel.Content = doctor.Name + " " + doctor.Surname;
            this.NavigationService.Navigate(sd);
        }

    }
}
