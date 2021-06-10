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

    public partial class ReportWindow : Window
    {
        private string doctor = "";
        private string specDoctor = "";
        private bool datesSelected = false;
        private List<string> doctorList = new List<string>();
        private List<string> specializationList = new List<string>();
        private DateTime startDate;
        private DateTime endDate;

        public ReportWindow()
        {
            InitializeComponent();

            endDatePicker.IsEnabled = false;
            doctorList.Add("Marija Petrović");
            doctorList.Add("Vladimir Vrbica");
            doctorList.Add("Nikolina Pavković");
            doctorList.Add("Sara Poparić");
            specializationList.Add("oftamologija");
            specializationList.Add("pedijatrija");
            specializationList.Add("ortopedija");
            specializationList.Add("hirurgija");
            doctors.ItemsSource = doctorList;
            specialization.ItemsSource = specializationList;
        }

        private void startDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
            if (date != null)
            {
                startDate = (DateTime)date;
                CalendarDateRange cdr = new CalendarDateRange(DateTime.MinValue, startDate);
                endDatePicker.BlackoutDates.Add(cdr);
                DateTime newStartDate = startDate.AddDays(7);
                CalendarDateRange cdr2 = new CalendarDateRange(newStartDate, DateTime.MaxValue);
                endDatePicker.BlackoutDates.Add(cdr2);
                startDatePicker.IsEnabled = false;
                endDatePicker.IsEnabled = true;
                lblStart.Content = startDate.ToShortDateString();
            }
        }

        private void endDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
            if (date != null)
            {
                endDate = (DateTime)date;
                endDatePicker.IsEnabled = false;
                lblFinish.Content = endDate.ToShortDateString();
                datesSelected = true;
                createTable();
            }
        }

        private IEnumerable<DateTime> EachCalendarDay(DateTime start, DateTime end)
        {
            for (var date = start.Date; date.Date <= end.Date; date = date.AddDays(1)) yield
            return date;
        }

        private void createTable()
        {
            double height = 427;
            foreach (DateTime date in EachCalendarDay(startDate, endDate))
            {
                double width = 22;
                TextBox textBox = new TextBox();
                textBox.Text = date.ToShortDateString();
                textBox.HorizontalAlignment = HorizontalAlignment.Left;
                textBox.Height = 23;
                textBox.Margin = new Thickness(width, height, 0, 0);
                textBox.TextWrapping = TextWrapping.Wrap;
                textBox.FontSize = 16;
                textBox.VerticalAlignment = VerticalAlignment.Top;
                textBox.Width = 109;
                textBox.IsReadOnly = true;
                textBox.BorderBrush = Brushes.Black;
                report.Children.Add(textBox);
                width += 107;
                TextBox textBox1 = new TextBox();
                textBox1.HorizontalAlignment = HorizontalAlignment.Left;
                textBox1.Height = 23;
                textBox1.Margin = new Thickness(width, height, 0, 0);
                textBox1.TextWrapping = TextWrapping.Wrap;
                textBox1.VerticalAlignment = VerticalAlignment.Top;
                textBox1.Width = 109;
                textBox1.IsEnabled = false;
                textBox1.BorderBrush = Brushes.Black;
                report.Children.Add(textBox1);
                CheckBox checkBox1 = new CheckBox();
                checkBox1.BorderBrush = Brushes.Black;
                checkBox1.BorderThickness = new Thickness(2);
                checkBox1.VerticalAlignment = VerticalAlignment.Top;
                checkBox1.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox1.Margin = new Thickness(width + 51, height + 6, 0, 0);
                report.Children.Add(checkBox1);
                width += 107;
                TextBox textBox2 = new TextBox();
                textBox2.HorizontalAlignment = HorizontalAlignment.Left;
                textBox2.Height = 23;
                textBox2.Margin = new Thickness(width, height, 0, 0);
                textBox2.TextWrapping = TextWrapping.Wrap;
                textBox2.VerticalAlignment = VerticalAlignment.Top;
                textBox2.Width = 109;
                textBox2.IsEnabled = false;
                textBox2.BorderBrush = Brushes.Black;
                report.Children.Add(textBox2);
                CheckBox checkBox2 = new CheckBox();
                checkBox2.BorderBrush = Brushes.Black;
                checkBox2.BorderThickness = new Thickness(2);
                checkBox2.VerticalAlignment = VerticalAlignment.Top;
                checkBox2.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox2.Margin = new Thickness(width + 51, height + 6, 0, 0);
                report.Children.Add(checkBox2);
                width += 107;
                TextBox textBox3 = new TextBox();
                textBox3.HorizontalAlignment = HorizontalAlignment.Left;
                textBox3.Height = 23;
                textBox3.Margin = new Thickness(width, height, 0, 0);
                textBox3.TextWrapping = TextWrapping.Wrap;
                textBox3.VerticalAlignment = VerticalAlignment.Top;
                textBox3.Width = 109;
                textBox3.IsEnabled = false;
                textBox3.BorderBrush = Brushes.Black;
                report.Children.Add(textBox3);
                CheckBox checkBox3 = new CheckBox();
                checkBox3.BorderBrush = Brushes.Black;
                checkBox3.BorderThickness = new Thickness(2);
                checkBox3.VerticalAlignment = VerticalAlignment.Top;
                checkBox3.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox3.Margin = new Thickness(width + 51, height + 6, 0, 0);
                report.Children.Add(checkBox3);
                width += 107;
                TextBox textBox4 = new TextBox();
                textBox4.HorizontalAlignment = HorizontalAlignment.Left;
                textBox4.Height = 23;
                textBox4.Margin = new Thickness(width, height, 0, 0);
                textBox4.TextWrapping = TextWrapping.Wrap;
                textBox4.VerticalAlignment = VerticalAlignment.Top;
                textBox4.Width = 109;
                textBox4.IsEnabled = false;
                textBox4.BorderBrush = Brushes.Black;
                report.Children.Add(textBox4);
                CheckBox checkBox4 = new CheckBox();
                checkBox4.BorderBrush = Brushes.Black;
                checkBox4.BorderThickness = new Thickness(2);
                checkBox4.VerticalAlignment = VerticalAlignment.Top;
                checkBox4.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox4.Margin = new Thickness(width + 51, height + 6, 0, 0);
                report.Children.Add(checkBox4);
                width += 107;
                TextBox textBox5 = new TextBox();
                textBox5.HorizontalAlignment = HorizontalAlignment.Left;
                textBox5.Height = 23;
                textBox5.Margin = new Thickness(width, height, 0, 0);
                textBox5.TextWrapping = TextWrapping.Wrap;
                textBox5.VerticalAlignment = VerticalAlignment.Top;
                textBox5.Width = 109;
                textBox5.IsEnabled = false;
                textBox5.BorderBrush = Brushes.Black;
                report.Children.Add(textBox5);
                CheckBox checkBox5 = new CheckBox();
                checkBox5.BorderBrush = Brushes.Black;
                checkBox5.BorderThickness = new Thickness(2);
                checkBox5.VerticalAlignment = VerticalAlignment.Top;
                checkBox5.HorizontalAlignment = HorizontalAlignment.Left;
                checkBox5.Margin = new Thickness(width + 51, height + 6, 0, 0);
                report.Children.Add(checkBox5);
                height += 22;

            }
        }

        private void specialization_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            specDoctor = (string)combo.SelectedItem;
            lblSpec.Content = specDoctor;
        }

        private void doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            doctor = (string)combo.SelectedItem;
            lblDoc.Content = doctor;
        }

        private void sendReport(object sender, RoutedEventArgs e)
        {
            if (!datesSelected)
            {
                MessageBox.Show("Tabela nije generisana!");
            }
            else if (doctor.Length == 0 || specDoctor.Length == 0)
            {
                MessageBox.Show("Informacije o doktoru nisu popunjene!");
            }
            else
            {
                try
                {
                    this.IsEnabled = false;
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        printDialog.PrintVisual(report, "invoice");
                        this.Close();
                    }
                }
                finally
                {
                    this.IsEnabled = true;
                }
            }
        }

    }
}

