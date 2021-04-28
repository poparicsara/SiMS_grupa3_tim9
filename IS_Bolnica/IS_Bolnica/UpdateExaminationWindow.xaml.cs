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
        private int ordination;
        private Doctor doctor = new Doctor();
        public UpdateExaminationWindow(int selectedIndex, Doctor doctor)
        {
            InitializeComponent();
            this.doctor = doctor;

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");

            dateTxt.Text = examinations.ElementAt(selectedIndex).Date.ToString("dd.MM.yyyy hh.mm");
            roomTxt.Text = examinations.ElementAt(selectedIndex).RoomRecord.roomPurpose.Name;
            patientNameTxt.Text = examinations.ElementAt(selectedIndex).Patient.Name;
            patientSurnameTxt.Text = examinations.ElementAt(selectedIndex).Patient.Surname;

            selectedExamination = selectedIndex;

            ordination = (int)Int64.Parse(roomTxt.Text);
        }

        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            Examination examination = new Examination();
            RoomPurpose purpose = new RoomPurpose();
            RoomRecord room = new RoomRecord();
            examination.Date = DateTime.Parse(dateTxt.Text);
            purpose.Name = roomTxt.Text;
            room.roomPurpose = purpose;
            patient.Name = patientNameTxt.Text;
            patient.Surname = patientSurnameTxt.Text;

            ExaminationsRecordFileStorage examinationsRecordFileStorage = new ExaminationsRecordFileStorage();
            List<Examination> examinations = examinationsRecordFileStorage.loadFromFile("examinations.json");
            examinations.ElementAt(selectedExamination).Date = examination.Date;
            examinations.ElementAt(selectedExamination).RoomRecord.roomPurpose = room.roomPurpose;
            examinations.ElementAt(selectedExamination).Patient.Name = patient.Name;
            examinations.ElementAt(selectedExamination).Patient.Surname = patient.Surname;

            examinationsRecordFileStorage.saveToFile(examinations, "examinations.json");

            DoctorWindow doctorWindow = new DoctorWindow(doctor);
            doctorWindow.dataGridExaminations.Items.Refresh();
            doctorWindow.Show();
            this.Close();
        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                                                "Update examination", MessageBoxButton.YesNo);

            switch (messageBox)
            {
                case MessageBoxResult.Yes:
                    DoctorWindow doctorWindow = new DoctorWindow(doctor);
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
    }
    
}
