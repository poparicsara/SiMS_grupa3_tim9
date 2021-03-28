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
using System.Collections.ObjectModel;

namespace IS_Bolnica.Secretary
{
    public partial class AddPatient : Window
    {
        private Patient patient = new Patient();
        private PatientRecordFileStorage storage = new PatientRecordFileStorage();
        public AddPatient()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void cancelAdding(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void addPatient(object sender, RoutedEventArgs e)
        {
            patient.Email = email.Text;
            patient.DateOfBirth = dateOfBirth.DisplayDate;
            patient.Name = name.Text;
            patient.Id = (int)Int64.Parse( id.Text);
            patient.Password = iniciallyPassword.Text;
            patient.Phone = (int)Int64.Parse(phone.Text);
            patient.Surname = surname.Text;
            patient.Username = username.Text;
            patient.UserType = UserType.patient;

            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");
            pacijenti.Add(patient);
            storage.saveToFile(pacijenti, "PatientRecordFileStorage.json");
            this.Close();

        }
    }
}
