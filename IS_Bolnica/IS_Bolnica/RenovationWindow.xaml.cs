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

namespace IS_Bolnica
{
    public partial class RenovationWindow : Window
    {
        public RenovationWindow()
        {
            InitializeComponent();
        }

        private void DoneButton(object sender, RoutedEventArgs e)
        {
            DateTime start = (DateTime)startDate.SelectedDate;
            int startDay = start.Day;
            int startMonth = start.Month;
            int startYear = start.Year;

            DateTime end = (DateTime)endDate.SelectedDate;
            int endDay = start.Day;
            int endMonth = start.Month;
            int endYear = start.Year;

        }
    }
}
