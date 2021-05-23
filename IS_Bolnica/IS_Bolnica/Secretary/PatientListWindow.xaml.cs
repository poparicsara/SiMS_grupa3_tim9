﻿using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace IS_Bolnica.Secretary
{
    public partial class PatientListWindow : Window, INotifyPropertyChanged
    {
        private List<User> users = new List<User>();
        private UsersFileStorage storage1 = new UsersFileStorage();
        private List<Patient> Pacijenti { get; set; } = new List<Patient>();
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        private UsersFileStorage usersStorage = new UsersFileStorage();
        private ExaminationsRecordFileStorage examinationStorage = new ExaminationsRecordFileStorage();
        private List<Examination> examinations = new List<Examination>();
        private OperationsFileStorage operationsStorage = new OperationsFileStorage();
        private List<Operation> operations = new List<Operation>();
        public event PropertyChangedEventHandler PropertyChanged;

        public PatientListWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            PatientList.ItemsSource = Pacijenti;
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            Secretary.AddPatient ap = new Secretary.AddPatient();
            ap.Show();
            this.Close();
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            int i = -1;
            i = PatientList.SelectedIndex;
            Patient patient = (Patient)PatientList.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to edit!");
            }
            else
            {
                Secretary.EditPatient ep = new Secretary.EditPatient(patient);
                setElementsEPW(ep, patient);
                ep.Show();
                this.Close();
            }

        }

        private void setElementsEPW(EditPatient ep, Patient patient)
        {
            ep.name.Text = patient.Name;
            ep.surname.Text = patient.Surname;
            ep.username.Text = patient.Username;
            ep.dateOfBirth.SelectedDate = new DateTime(patient.DateOfBirth.Year, patient.DateOfBirth.Month, patient.DateOfBirth.Day);
            ep.iniciallyPassword.Text = patient.Password;
            ep.id.Text = patient.Id.ToString();
            ep.phone.Text = patient.Phone.ToString();
            ep.email.Text = patient.Email;
            ep.adress.Text = patient.Address.Street + " "
                + patient.Address.NumberOfBuilding + "/"
                + patient.Address.Floor + "/"
                + patient.Address.Apartment;
            ep.city.Text = patient.Address.City.name + " "
                + Convert.ToString(patient.Address.City.postalCode);
            ep.country.Text = patient.Address.City.Country.name;
            ep.debit.Text = Convert.ToString(patient.Debit);
            List<string> alergeni = patient.Allergens;
            foreach (var alergen in alergeni)
            {
                ep.allergens.Text += alergen + ",";

            }
            String pom = ep.allergens.Text;
            ep.allergens.Text = pom.Remove(pom.Length - 1, 1);
        }

        private void deletePatient(object sender, RoutedEventArgs e)
        {
            
            int i = PatientList.SelectedIndex;

            Patient patient = (Patient)PatientList.SelectedItem;

            if (i == -1)
            {
                MessageBox.Show("You didn't choose patient which you want to delete!");
            }
            else
            {

                MessageBoxResult result = MessageBox.Show("Da li stvarno želite da obrišete pacijenta?", "Brisanje pacijenta", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Pacijenti = removePatient(patient);
                        storage.saveToFile(Pacijenti, "PatientRecordFileStorage.json");

                        users = removeUser(patient);
                        usersStorage.saveToFile(users, "UsersFileStorage.json");

                        examinations = removePatientsExaminations(patient);
                        examinationStorage.saveToFile(examinations, "Pregledi.json");

                        operations = removePatientOperations(patient);
                        operationsStorage.saveToFile(operations, "operations.json");

                        PatientListWindow plw = new PatientListWindow();

                        plw.Show();
                        this.Close();

                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private List<Patient> removePatient(Patient patient)
        {
            Pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            for (int k = 0; k < Pacijenti.Count; k++)
            {
                if (Pacijenti[k].Id.Equals(patient.Id))
                {
                    Pacijenti.RemoveAt(k);
                }
            }

            return Pacijenti;
        }

        private List<User> removeUser(Patient patient)
        {
            users = usersStorage.loadFromFile("UsersFileStorage.json");
            for (int k = 0; k < users.Count; k++)
            {
                if (users[k].Id.Equals(patient.Id))
                {
                    users.RemoveAt(k);
                }
            }

            return users;
        }

        private List<Examination> removePatientsExaminations(Patient patient)
        {
            examinations = examinationStorage.loadFromFile("Pregledi.json");
            for (int k = 0; k < examinations.Count; k++)
            {
                if (examinations[k].Patient.Id.Equals(patient.Id))
                {
                    examinations.RemoveAt(k);
                }
            }

            return examinations;
        }

        private List<Operation> removePatientOperations(Patient patient)
        {
            operations = operationsStorage.loadFromFile("operations.json");
            for (int k = 0; k < operations.Count; k++)
            {
                if (operations[k].Patient.Id.Equals(patient.Id))
                {
                    operations.RemoveAt(k);
                }
            }
            return operations;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Secretary.ActionBarWindow abw = new Secretary.ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void pretraziBox_KeyUp(object sender, KeyEventArgs e)
        {
            var filtered = Pacijenti.Where(patient => patient.Id.StartsWith(pretraziBox.Text));

            PatientList.ItemsSource = filtered;
        }
    }
}