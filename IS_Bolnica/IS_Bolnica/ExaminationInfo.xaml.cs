﻿using IS_Bolnica.Model;
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

namespace IS_Bolnica
{
    public partial class ExaminationInfo : Window
    {
        private int selectedPatient;
        public ExaminationInfo(int selectedIndex)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");
            PrescriptionFileStorage prescriptionFileStorage = new PrescriptionFileStorage();
            List<Prescription> prescriptions = prescriptionFileStorage.loadFromFile("prescriptions.json");

            patientNameTxt.Text = examinations.ElementAt(selectedIndex).Patient.Name;
            patientSurnameTxt.Text = examinations.ElementAt(selectedIndex).Patient.Surname;
            dateOfBirthTxt.Text = examinations.ElementAt(selectedIndex).Patient.DateOfBirth.ToString("dd.MM.yyyy");
            jmbgTxt.Text = examinations.ElementAt(selectedIndex).Patient.Id.ToString();
            healthCardNumberTxt.Text = examinations.ElementAt(selectedIndex).Patient.HealthCardNumber;
            //addressTxt.Text = examinations.ElementAt(selectedIndex).Patient.Address.Street;

            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Patient.Name.Equals(patientNameTxt.Text))
                {
                    medicationsList.Items.Add(prescription.MedicationName);
                }
            }

            selectedPatient = selectedIndex;
        }

        private void anamnezaClicked(object sender, RoutedEventArgs e)
        {
            Diagnosis diagnosis = new Diagnosis();
            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

            diagnosis.patientNameTxt.Text = patientNameTxt.Text;
            diagnosis.patientSurnameTxt.Text = patientSurnameTxt.Text;
            diagnosis.dateOfBirthTxt.Text = dateOfBirthTxt.Text;
            diagnosis.jmbgTxt.Text = jmbgTxt.Text;
            diagnosis.healthCardNumberTxt.Text = healthCardNumberTxt.Text;
           // diagnosis.addressTxt.Text = addressTxt.Text;
            diagnosis.dateOfExaminationTxt.Text = examinations.ElementAt(selectedPatient).Date.ToString();
            diagnosis.Show();
        }
    }
}
