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
        }

        private void DoneButtonClicked(object sender, RoutedEventArgs e)
        {
            SetRenovationAttributes();
            RenovationService service = new RenovationService();
            service.AddRenovation(renovation);

            this.Close();
        }

        private void SetRenovationAttributes()
        {
            renovation.Room = room;
            DateTime start = (DateTime) startDate.SelectedDate;
            renovation.StartDate = new DateTime(start.Year, start.Month, start.Day, 0, 0, 0);
            DateTime end = (DateTime) endDate.SelectedDate;
            renovation.EndDate = new DateTime(end.Year, end.Month, end.Day, 0, 0, 0);
        }

        private void ClosingWindow(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Director director = new Director();
            RoomWindow rw = new RoomWindow(director);
            rw.Show();
        }
    }

}
