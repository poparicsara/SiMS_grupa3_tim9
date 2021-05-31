﻿using IS_Bolnica.Services;
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
    /// <summary>
    /// Interaction logic for PregledAnamneza.xaml
    /// </summary>
    /// 
    public partial class PregledAnamneza : Window
    {
        private AnamnesisService anamnesisService = new AnamnesisService();
        public PregledAnamneza()
        {
            InitializeComponent();

            AnamnezeDataBinding.ItemsSource = anamnesisService.getPatientAnamneses(PatientWindow.username_patient);
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BeleskeButtonClicked(object sender, RoutedEventArgs e)
        {
            Beleske notes = new Beleske();
            notes.Show();
        }
    }
}
