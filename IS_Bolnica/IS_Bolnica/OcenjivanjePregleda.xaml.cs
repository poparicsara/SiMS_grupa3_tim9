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

namespace IS_Bolnica
{
    /// <summary>
    /// Interaction logic for OcenjivanjePregleda.xaml
    /// </summary>
    public partial class OcenjivanjePregleda : Window
    {
        public OcenjivanjePregleda(Examination pregled)
        {
            InitializeComponent();

            DoktorTextBox.Text = pregled.Doctor.Name + " " + pregled.Doctor.Surname;
        }

        private void ButtonZabeleziClicked(object sender, RoutedEventArgs e)
        {
            EvaluationRepository exStorage = new EvaluationRepository();
            List<Evaluation> ocene = exStorage.loadFromFile("Ocene.json");
            Evaluation ocena = new Evaluation();
            Doctor doctor = new Doctor();
            String[] nameAndSurname = DoktorTextBox.Text.Split(' ');
            doctor.Name = nameAndSurname[0];
            doctor.Surname = nameAndSurname[1];
            Patient patient = new Patient();
            patient.Username = PatientWindow.username_patient;
            ocena.Doctor = doctor;
            ocena.Patient = patient;
            ocena.Assessment = Convert.ToInt32(OcenaComboBox.Text);
            ocena.Comment = CommentTextBox.Text;
            ocena.Bolnica = "";

            ocene.Add(ocena);
            this.Close();
            exStorage.saveToFile(ocene, "Ocene.json");
        }

        private void BackButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}