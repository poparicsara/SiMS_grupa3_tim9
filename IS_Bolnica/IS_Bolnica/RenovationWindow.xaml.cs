using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class RenovationWindow : Window
    {
        private Room room;
        private Renovation renovation = new Renovation();

        public RenovationWindow(Room selectedRoom)
        {
            InitializeComponent();

            room = selectedRoom;

            startDate.Focusable = true;
            startDate.Focus();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            if (AreDatesChosen())
            {
                MessageBox.Show("Morate odabrati oba datuma!");
            } 
            else if (SetRenovationAttributes())
            {
                RenovationService service = new RenovationService();
                service.AddRenovation(renovation);
                this.Close();
            }
        }

        private bool AreDatesChosen()
        {
            return startDate.SelectedDate == null || endDate.SelectedDate == null;
        }

        private bool SetRenovationAttributes()
        {
            renovation.Room = room;
            DateTime start = (DateTime) startDate.SelectedDate;
            renovation.StartDate = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            return SetEndDate();
        }

        private bool SetEndDate()
        {
            DateTime end = (DateTime)endDate.SelectedDate;
            if (renovation.StartDate > end)
            {
                MessageBox.Show("Datum kraja renoviranja mora biti nakon datuma početka renoviranja!");
                return false;
            }
            else
            {
                renovation.EndDate = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
                return true;
            }
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            RoomWindow rw = new RoomWindow();
            rw.Show();
        }

        private void CancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}
