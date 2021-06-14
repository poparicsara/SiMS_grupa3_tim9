using System;
using System.Windows;
using System.Windows.Controls;
using IS_Bolnica.GUI.Secretary.View;
using IS_Bolnica.Secretary;
using Model;

namespace IS_Bolnica
{
    public partial class SekretarWindow : Window
    {
        public static Frame MyFrame = new Frame();
        public SekretarWindow(string username)
        {
            InitializeComponent();
            this.DataContext = this;
            MyFrame = MainFrame;
            MyFrame.NavigationService.Navigate(new SecretaryProfile(username, this));
        }

    }
}
