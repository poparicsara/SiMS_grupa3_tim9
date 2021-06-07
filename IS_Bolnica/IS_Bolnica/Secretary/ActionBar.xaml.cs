using System.Windows;
using System.Windows.Controls;

namespace IS_Bolnica.Secretary
{
    public partial class ActionBar : Page
    {
        public ActionBar()
        {
            InitializeComponent();
        }

        private void SpisakPacijenata_Selected(object sender, RoutedEventArgs e)
        {
            PatientList pl = new PatientList(this);
            this.NavigationService.Navigate(pl);
        }

        private void BlokiraniPacijenti_Selected(object sender, RoutedEventArgs e)
        {
            BlockedPatientsList bpl = new BlockedPatientsList(this);
            this.NavigationService.Navigate(bpl);
        }

        private void SpisakGuestNaloga_Selected(object sender, RoutedEventArgs e)
        {
            GuestUserList gul = new GuestUserList(this);
            this.NavigationService.Navigate(gul);
        }

        private void SpisakObavestenja_Selected(object sender, RoutedEventArgs e)
        {
            NotificationList nl = new NotificationList(this);
            this.NavigationService.Navigate(nl);
        }

        private void SpisakPregleda_Selected(object sender, RoutedEventArgs e)
        {
            ExaminationList el = new ExaminationList(this);
            this.NavigationService.Navigate(el);
        }

        private void SpisakOperacija_Selected(object sender, RoutedEventArgs e)
        {
            OperationList ol = new OperationList(this);
            this.NavigationService.Navigate(ol);
        }

        private void ZakaziHitanPregled_Selected(object sender, RoutedEventArgs e)
        {
            AddUrgentExaminationPage auep = new AddUrgentExaminationPage(this);
            this.NavigationService.Navigate(auep);
        }

        private void ZakaziHitnuOperaciju_Selected(object sender, RoutedEventArgs e)
        {
            AddUrgentOperation auo = new AddUrgentOperation(this);
            this.NavigationService.Navigate(auo);
        }

        private void Profil_Selected(object sender, RoutedEventArgs e)
        {
            SecretaryProfile sp = new SecretaryProfile();
            this.NavigationService.Navigate(sp);
        }

        private void SpisakLekara_Selected(object sender, RoutedEventArgs e)
        {
            DoctorList dl = new DoctorList(this);
            this.NavigationService.Navigate(dl);
        }

        private void Opcije_Selected(object sender, RoutedEventArgs e)
        {
            Options o = new Options(this);
            this.NavigationService.Navigate(o);
        }

        private void Izvestaj_selected(object sender, RoutedEventArgs e)
        {
            ReportForm rf = new ReportForm(this);
            this.NavigationService.Navigate(rf);
        }
    }
}
