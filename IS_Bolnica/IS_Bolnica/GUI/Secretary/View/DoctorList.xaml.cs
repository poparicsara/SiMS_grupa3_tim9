using System.Windows.Controls;
using System.Windows.Input;
using IS_Bolnica.GUI.Secretary.ViewModel;
using IS_Bolnica.Patterns;
using IS_Bolnica.Secretary;
using IS_Bolnica.Services;

namespace IS_Bolnica.GUI.Secretary.View
{
    public partial class DoctorList : Page
    {
        private Page previousPage;
        private DoctorService doctorService = new DoctorService();
        public DoctorList(Page previousPage)
        {
            InitializeComponent();
            DataContext = new DoctorListVM();
        }

        private void pretraziBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            SearchGridTemplate<global::Model.Doctor> doctors = new SearchDoctors();
            var filtered = doctors.GetSearchedEntities(pretraziBox.Text.ToLower());
            DoctorListGrid.ItemsSource = filtered;
        }

        private void DoctorListGrid_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(DoctorListGrid.SelectedIndex == -1) return;
            global::Model.Doctor doctor = (global::Model.Doctor) DoctorListGrid.SelectedItem;
            SelectedDoctor sd = new SelectedDoctor(doctor);
            sd.doctorNameSurnameLabel.Content = doctor.Name + " " + doctor.Surname;
            this.NavigationService.Navigate(sd);
        }

    }
}
