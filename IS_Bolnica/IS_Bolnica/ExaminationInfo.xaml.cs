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
        private Appointment examination;
        private List<Appointment> loggedExaminations;
        public ExaminationInfo(int selectedIndex, List<Appointment> loggedDoctorExaminations)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();

            this.loggedExaminations = loggedDoctorExaminations;
            PrescriptionFileStorage prescriptionFileStorage = new PrescriptionFileStorage();
            List<Prescription> prescriptions = prescriptionFileStorage.loadFromFile("prescriptions.json");
            AnamnesisRepository anamnesisRepository = new AnamnesisRepository();
            List<Anamnesis> anamneses = anamnesisRepository.loadFromFile("anamneses.json");

            this.examination = loggedExaminations.ElementAt(selectedIndex);
            patientTxt.Text = examination.Patient.Name + ' ' + examination.Patient.Surname;
            dateOfBirthTxt.Text = examination.Patient.DateOfBirth.ToString();
            jmbgTxt.Text = examination.Patient.Id;
            healthCardNumberTxt.Text = examination.Patient.HealthCardNumber;
            addressTxt.Text = examination.Patient.Address.Street + ", " + examination.Patient.Address.City.name;

            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Patient.Id.Equals(jmbgTxt.Text))
                {
                    medicationsList.Items.Add(prescription.Therapy.MedicationName);
                }
            } 

            foreach (Anamnesis anamnesis in anamneses)
            {
                if (anamnesis.Patient.Id.Equals(jmbgTxt.Text))
                {
                    historyList.Items.Add(anamnesis.Diagnosis);
                }
            }

            if (examination.Patient.Id.Equals(jmbgTxt.Text))
            {
                for (int i = 0; i < examination.Patient.Allergens.Count; i++)
                {
                    allergiesList.Items.Add(examination.Patient.Allergens[i]);
                }
            }

            selectedPatient = selectedIndex;
        }

        private void anamnezaClicked(object sender, RoutedEventArgs e)
        {
            this.examination = loggedExaminations.ElementAt(selectedPatient);

            Diagnosis diagnosis = new Diagnosis(examination, loggedExaminations);

            diagnosis.Show();
            this.Close();

        }
    }
}
