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
using IS_Bolnica.Model;
using IS_Bolnica.Services;

namespace IS_Bolnica.DoctorUI
{
    public partial class FeedbackWindow : Window
    {
        private UserService userService = new UserService();
        private FeedbackService feedbackService = new FeedbackService();
        private Feedback feedback = new Feedback();
        public FeedbackWindow()
        {
            InitializeComponent();
        }

        private void SendFeedbackButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Suggestions = suggestionsTxt.Text;
            feedback.Comment = commentTxt.Text;

            feedbackService.SaveFeedback(feedback);

            this.Close();
        }

        private void ExaminationsButtonClick(object sender, RoutedEventArgs e)
        {
            DoctorStartWindow doctorStartWindow = new DoctorStartWindow();
            doctorStartWindow.Show();
            this.Close();
        }

        private void OperationButtonClick(object sender, RoutedEventArgs e)
        {
            OperationsWindow operationsWindow = new OperationsWindow();
            operationsWindow.Show();
            this.Close();
        }

        private void NotificationsButtonClick(object sender, RoutedEventArgs e)
        {
            NotificationsWindow notificationsWindow = new NotificationsWindow();
            notificationsWindow.Show();
            this.Close();
        }

        private void StatisticsButtonClick(object sender, RoutedEventArgs e)
        {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();
            this.Close();
        }

        private void SingOutButtonClick(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Da li ste sigurni da želite da se odjavite?",
                "Odjavljivanje", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    userService.LogOut();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void SettingsButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void MedicamentsButtonClick(object sender, RoutedEventArgs e)
        {
            MedicamentsWindow medicamentsWindow = new MedicamentsWindow();
            medicamentsWindow.Show();
            this.Close();
        }

        private void ZeroButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 0;
        }

        private void OneButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 1;
        }

        private void TwoButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 2;
        }

        private void ThreeButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 3;
        }

        private void FourButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 4;
        }

        private void FiveButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 5;
        }
    }
}
