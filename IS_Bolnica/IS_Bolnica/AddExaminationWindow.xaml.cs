﻿using Model;
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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class AddExaminationWindow : Window
    {
        public AddExaminationWindow()
        {
            InitializeComponent();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    
                    break;
            }
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Examination examination = new Examination();
            examination.Date = DateTime.Parse(dateTxt.Text);
            examination.RoomName = roomTxt.Text;
            examination.NameSurname = patientTxt.Text;

            ExaminationsRecordFileStorage storage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = storage.loadFromFile("examinations.json");
            examinations.Add(examination);
            storage.saveToFile(examinations, "examinations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();

            this.Close();
        }
    }
}
