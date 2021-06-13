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

namespace IS_Bolnica
{
    public partial class FeedBackByDirector : Window
    {
        private FeedbackService feedbackService = new FeedbackService();
        private Feedback feedback = new Feedback();

        public FeedBackByDirector()
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

        private void ZeroButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 0;
            zero.IsEnabled = false;
        }

        private void OneButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 1;
            one.IsEnabled = false;
        }

        private void TwoButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 2;
            two.IsEnabled = false;
        }

        private void ThreeButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 3;
            three.IsEnabled = false;
        }

        private void FourButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 4;
            four.IsEnabled = false;
        }

        private void FiveButtonClick(object sender, RoutedEventArgs e)
        {
            feedback.Grade = 5;
            five.IsEnabled = false;
        }
    }
}
