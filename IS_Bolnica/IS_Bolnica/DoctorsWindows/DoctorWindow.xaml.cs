using IS_Bolnica.DoctorsWindows;
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

namespace IS_Bolnica
{
    public partial class DoctorWindow : Window
    {
        public List<Examination> Examinations
        {
            get;
            set;
        }
        public DoctorWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            ExaminationsRecordFileStorage examinationFileStorage = new ExaminationsRecordFileStorage();
            Patient patient = new Patient();
            patient.Name = "Petar";
            patient.Surname = "Petrovic";
            string nameAndSurname = patient.Name + patient.Surname;
            RoomRecord room = new RoomRecord();
            room.Id = "room 2b";

            Examinations = new List<Examination>();
            Examinations.Add(new Examination { Date = DateTime.Now.Date, RoomName = "room 2b", NameSurname = patient.Name + " " + patient.Surname});

            examinationFileStorage.saveToFile(Examinations, "examinations.json");
            
        }

        private void addExaminationButton(object sender, RoutedEventArgs e)
        {
            AddExaminationWindow addExaminationWindow = new AddExaminationWindow();
            addExaminationWindow.Show();

        }

        private void addOperationButton(object sender, RoutedEventArgs e)
        {
            AddOperationWindow addOperationWindow = new AddOperationWindow();
            addOperationWindow.Show();
        }
    }
}
