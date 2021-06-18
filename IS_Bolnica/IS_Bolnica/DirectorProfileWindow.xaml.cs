using Model;
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
    public partial class DirectorProfileWindow : Window
    {
        private ChangeInventoryPlaceService changeService = new ChangeInventoryPlaceService();
        private RenovationService renovationService = new RenovationService();

        public DirectorProfileWindow(String phone, String email)
        {
            InitializeComponent();

            if (!phone.Equals("0601234567"))
            {
                this.phone.Content = phone;
            }

            if (!email.Equals("ivanivanovic@gmail.com"))
            {
                this.email.Content = email;
            }

            changeService.CheckUnexecutedShiftings();
            //renovationService.CheckUnexecutedMergings();
            //renovationService.CheckUnexecutedSeparations();

            this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
        }

        private void HandleEsc(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                    "Odjava", MessageBoxButton.YesNo);
                switch (messageBox)
                {
                    case MessageBoxResult.Yes:
                        this.Close();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            RoomWindow uw = new RoomWindow();
            uw.Show();
            this.Close();
        }

        private void InventoryButtonClicked(object sender, RoutedEventArgs e)
        {
            InventoryWindow uw = new InventoryWindow();
            uw.Show();
            this.Close();
        }

        private void MedicamentButtonClicked(object sender, RoutedEventArgs e)
        {
            MedicamentWindow mw = new MedicamentWindow();
            mw.Show();
            this.Close();

        }

        private void LogOutButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void EditButtonClicked(object sender, RoutedEventArgs e)
        {
            EditDirectorProfileWindow editWindow = new EditDirectorProfileWindow(phone.Content.ToString(), email.Content.ToString());
            editWindow.Show();
            this.Close();
        }

        private void NotificationButtonClicked(object sender, RoutedEventArgs e)
        {
            DirectorNotificationWindow dw = new DirectorNotificationWindow();
            dw.Show();
            this.Close();
        }

        private void SignOutButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjava", MessageBoxButton.YesNo);
            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void ReportButtonClicked(object sender, RoutedEventArgs e)
        {
            ReportWindow rw = new ReportWindow();
            rw.Show();
            this.Close();
        }

        private void FeedBackButtonClicked(object sender, RoutedEventArgs e)
        {
            FeedBackByDirector fw = new FeedBackByDirector();
            fw.Show();
            this.Close();
        }
    }
}
