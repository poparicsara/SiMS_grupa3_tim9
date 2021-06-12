﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.Services;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class Feedback : Page
    {
        private UserService userService = new UserService();
        private FeedbackService feedbackService = new FeedbackService();
        private Model.Feedback feedback = new Model.Feedback();

        public Feedback()
        {
            InitializeComponent();
        }

        private void sendFeedBack(object sender, RoutedEventArgs e)
        {
            feedback.Suggestions = suggestionsTxt.Text;
            feedback.Comment = commentTxt.Text;

            feedbackService.SaveFeedback(feedback);
            MessageBox.Show("Uspešno ste poslali feedback. Hvala!");
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBar ab = new ActionBar();
            this.NavigationService.Navigate(ab);
        }
    }
}
