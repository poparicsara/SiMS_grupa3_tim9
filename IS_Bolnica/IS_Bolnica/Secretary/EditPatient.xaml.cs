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
using Model;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for EditPatient.xaml
    /// </summary>
    public partial class EditPatient : Window
    {
        int index;
        public EditPatient(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void cancelEditing(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void editPatient(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Patient> pacijenti = new ObservableCollection<Patient>();
            PatientRecordFileStorage storage = new PatientRecordFileStorage();

            pacijenti = storage.loadFromFile("PatientRecordFileStorage.json");

            pacijenti[index].Email = email.Text;
            pacijenti[index].DateOfBirth = dateOfBirth.DisplayDate;
            pacijenti[index].Name = name.Text;
            pacijenti[index].Id = (int)Int64.Parse(id.Text);
            pacijenti[index].Password = iniciallyPassword.Text;
            pacijenti[index].Phone = (int)Int64.Parse(phone.Text);
            pacijenti[index].Surname = surname.Text;
            pacijenti[index].Username = username.Text;
            pacijenti[index].UserType = UserType.patient;

            storage.saveToFile(pacijenti, "PatientRecordFileStorage.json");

            SekretarWindow sw = new SekretarWindow();
            sw.Show();
            this.Close();


        }
    }
}
