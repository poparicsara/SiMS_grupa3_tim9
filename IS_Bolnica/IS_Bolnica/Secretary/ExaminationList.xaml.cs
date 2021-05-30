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
    /// <summary>
    /// Interaction logic for ExaminationList.xaml
    /// </summary>
    public partial class ExaminationList : Page
    {
        private Appointment appointment = new Appointment();
        private AppointmentService appointmentService = new AppointmentService();

        public ExaminationList()
        {
            InitializeComponent();
            this.DataContext = this;

            ExaminationListGrid.ItemsSource = appointmentService.getExaminations();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }

        private void addExamination(object sender, RoutedEventArgs e)
        {

        }

        private void editExamination(object sender, RoutedEventArgs e)
        {

        }

        private void deleteExamination(object sender, RoutedEventArgs e)
        {

        }
    }
}
