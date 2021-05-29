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
using System.Windows.Shapes;
using IS_Bolnica.Services;

namespace IS_Bolnica
{
    public partial class DoctorStartWindow : Window
    {
        private AppointmentService appointmentService = new AppointmentService();
        public DoctorStartWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            examinationsDataGrid.ItemsSource = appointmentService.getDoctorsExaminations();
        }
    }
}
