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

namespace IS_Bolnica.DoctorsWindows
{
    public partial class UpdateExaminationWindow : Window
    {
        private int selectedExamination;
        public UpdateExaminationWindow(int selectedIndex)
        {
            InitializeComponent();

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

            dateTxt.Text = examinations.ElementAt(selectedIndex).Date.ToString();
            roomTxt.Text = examinations.ElementAt(selectedIndex).RoomName;
            patientTxt.Text = examinations.ElementAt(selectedIndex).NameSurname;

            selectedExamination = selectedIndex;
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Examination examination = new Examination();
            examination.Date = DateTime.Parse(dateTxt.Text);
            examination.RoomName = roomTxt.Text;
            examination.NameSurname = patientTxt.Text;

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");
            examinations.ElementAt(selectedExamination).Date = examination.Date;
            examinations.ElementAt(selectedExamination).RoomName = examination.RoomName;
            examinations.ElementAt(selectedExamination).NameSurname = examination.NameSurname;

            examinationsRecordFileStorage.saveToFile(examinations, "examinations.json");

            DoctorWindow doctorWindow = new DoctorWindow();
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
