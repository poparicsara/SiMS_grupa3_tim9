using IS_Bolnica.Model;
using IS_Bolnica.Services;
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
using IS_Bolnica.GUI.Patient.View;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for MyAppointments.xaml
    /// </summary>

    public partial class MyAppointments : Page
    {
        private AppointmentService appointmentService = new AppointmentService();
        private FindAttributesService findAttributesService = new FindAttributesService();
        private Point point = new Point();

        public MyAppointments()
        {
            InitializeComponent();
            List<Appointment> patientAppointment = appointmentService.FindPatientAppointments(PatientWindow.loggedPatient);

            foreach (Appointment appointment in patientAppointment)
            {
                if (appointmentService.checkAppointment(appointment))
                    PatientWindow.MyFrame.NavigationService.Navigate(new NewEvaluationForAppointment(appointment));
            }

            AppointmentsDataBinding.ItemsSource = appointmentService.FindPatientAppointments(PatientWindow.loggedPatient);
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new AddNewAppointment());
        }

        private void RemoveButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!findAttributesService.checkSelectedIndex(AppointmentsDataBinding.SelectedIndex))
            {
                Appointment selectedAppointment = appointmentService.findSelectedPatientAppointment(AppointmentsDataBinding.SelectedIndex);

                if (!appointmentService.checkDateOfAppointment(selectedAppointment))
                    PatientWindow.MyFrame.NavigationService.Navigate(new ConfirmDeletingAppointment(AppointmentsDataBinding.SelectedIndex));
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Ne mozete da oktazete pregled jer je zakazan u periodu od naredna dva dana!"));
            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Oznacite pregled koji zelite da otkazete!"));
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            if (!findAttributesService.checkSelectedIndex(AppointmentsDataBinding.SelectedIndex))
            {
                Appointment selectedAppointment = appointmentService.findSelectedPatientAppointment(AppointmentsDataBinding.SelectedIndex);

                if (!appointmentService.checkDateOfAppointment(selectedAppointment))
                    PatientWindow.MyFrame.NavigationService.Navigate(new EditAppointment(AppointmentsDataBinding.SelectedIndex));
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Ne mozete da izmenite pregled jer je zakazan u periodu od naredna dva dana!"));
            }
            else
                PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Oznacite pregled koji zelite da izmenite!"));
        }

        private void NotificationsButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientNotificationsPage());
        }

        private void EvaluationsButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new PatientEvaluations());
        }

        private void HealthButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new ShowAnamneses());
        }

        private void CalendarButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new CalendarForAppointments());
        }

        private void SearchKeyUp(object sender, KeyEventArgs e)
        {
            List<Appointment> patientAppointment = appointmentService.FindPatientAppointments(PatientWindow.loggedPatient);
            var filtered = patientAppointment.Where(apppointment => apppointment.Doctor.Name.ToLower().Contains(SearchBox.Text.ToLower()));
            AppointmentsDataBinding.ItemsSource = filtered;
        }

        private void DataGridPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            point = e.GetPosition(null);
        }

        private void DataGridMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = point - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                DataGrid dataGrid = sender as DataGrid;
                DataGridRow dataGridRow =
                    FindAncestor<DataGridRow>((DependencyObject)e.OriginalSource);

                if (dataGridRow == null) return;


                Appointment appointmentForDragAndDrop = (Appointment)dataGrid.ItemContainerGenerator.
                    ItemFromContainer(dataGridRow);

                DataObject dragData = new DataObject("Appointment", appointmentForDragAndDrop);
                DragDrop.DoDragDrop(dataGridRow, dragData, DragDropEffects.Move);
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void DataGridDragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("Appointment") || e.Source == sender)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void DeleteAppoinmentDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Appointment"))
            {
                Appointment selectedAppointment = e.Data.GetData("Appointment") as Appointment;
                if (!findAttributesService.checkSelectedIndex(AppointmentsDataBinding.SelectedIndex))
                {

                    if (!appointmentService.checkDateOfAppointment(selectedAppointment))
                        PatientWindow.MyFrame.NavigationService.Navigate(new ConfirmDeletingAppointment(AppointmentsDataBinding.SelectedIndex));
                    else
                        PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Ne mozete da oktazete pregled jer je zakazan u periodu od naredna dva dana!"));
                }
                else
                    PatientWindow.MyFrame.NavigationService.Navigate(new InformationPage("UPOZORENJE!", "Oznacite pregled koji zelite da otkazete!"));
            }
        }

        private void ReportButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new ChoosePeriodForReportPage());
        }
    }
}
