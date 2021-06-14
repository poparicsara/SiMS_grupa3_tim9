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
using IS_Bolnica.Model;
using IS_Bolnica.Services;
using Model;

namespace IS_Bolnica.PatientPages
{
    /// <summary>
    /// Interaction logic for AddNewFeedback.xaml
    /// </summary>
    public partial class AddNewFeedback : Page
    {
        private FeedbackService feedbackService = new FeedbackService();
        private Feedback feedback = new Feedback();
        public AddNewFeedback()
        {
            InitializeComponent();
        }

        private void ButtonAddClicked(object sender, RoutedEventArgs e)
        {
            feedback.Suggestions = SuggestionText.Text;
            feedback.Comment = CommentText.Text;

            feedbackService.SaveFeedback(feedback);

            PatientWindow.MyFrame.NavigationService.Navigate(new StartPage());
        }

        private void DeclineButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new StartPage());
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            PatientWindow.MyFrame.NavigationService.Navigate(new StartPage());
        }

        private void GradeZeroButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 0;
        }

        private void GradeOneButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 1;
        }

        private void GradeTwoButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 2;
        }

        private void GradeThreeButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 3;
        }

        private void GradeFourButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 4;
        }

        private void GradeFiveButtonClicked(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 5;
        }
    }
}
