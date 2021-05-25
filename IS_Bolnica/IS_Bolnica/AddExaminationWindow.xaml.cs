﻿using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public List<RoomRecord> Rooms { get; set; }
        public List<int> RoomId { get; set; } = new List<int>();
        private RoomRecordFileStorage roomStorage = new RoomRecordFileStorage();
        public List<Patient> Patients { get; set; } = new List<Patient>();
        private PatientRecordFileStorage patientStorage = new PatientRecordFileStorage();
        public List<int> Hours { get; set; } = new List<int>();
        public List<Doctor> Doctors { get; set; }
        private DoctorRepository doctorStorage = new DoctorRepository();
        private List<string> doctorNameAndSurname = new List<string>();
        private List<string> specialistNameAndSurname = new List<string>();
        private List<Specialization> specializations = new List<Specialization>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        public List<Appointment> Appointments { get; set; }
        private Appointment appointment = new Appointment();
        public AddExaminationWindow()
        {
            InitializeComponent();

            Rooms = roomStorage.loadFromFile("Sobe.json");

            foreach (RoomRecord room in Rooms)
            {
                if (room.roomPurpose.Name == "Ordinacija")
                {
                    RoomId.Add(room.Id);
                }
            }

            for (int i = 7; i < 20; i++)
            {
                Hours.Add(i);
            }

            hourBox.ItemsSource = Hours;

            List<int> Minutes = new List<int>();
            Minutes.Add(00);
            Minutes.Add(30);
            minuteBox.ItemsSource = Minutes;

        }

        private void cancelButtonClicked(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBox = MessageBox.Show("Are you sure you want to discard your changes?",
                "Scheduling", MessageBoxButton.YesNo);

            switch(messageBox)
            {
                case MessageBoxResult.Yes:

                    DoctorWindow doctorWindow = new DoctorWindow();
                    doctorWindow.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:

                    break;
            }
        }
        private void saveButtonClicked(object sender, RoutedEventArgs e)
        {
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");
            Doctors = doctorStorage.loadFromFile("Doctors.json");

            int cnt = 0;
            string[] patientNameAndSurname = patientTxt.Text.Split(' ');

            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    appointment.Doctor = doctor;
                }
            }

            foreach (Patient patient in Patients)
            {
                if (patient.Id.Equals(jmbgTxt.Text))
                {
                    appointment.Patient = patient;
                    cnt++;
                }
            }

            if ((patientNameAndSurname[0] != appointment.Patient.Name) || (patientNameAndSurname[1] != appointment.Patient.Surname))
            {
                MessageBox.Show("Pogresno ime ili prezime!");
            }
            else if (cnt == 0)
            {
                MessageBox.Show("Pacijent sa ovim JMBG-om ne postoji!");
            }
            else
            {
                DateTime date = new DateTime();
                date = (DateTime)datePicker.SelectedDate;
                int hour = Convert.ToInt32(hourBox.Text);
                int minute = Convert.ToInt32(minuteBox.Text);
                appointment.StartTime = new DateTime(date.Year, date.Month, date.Day, hour, minute, 0);
                appointment.RoomRecord = new RoomRecord();
                appointment.AppointmentType = AppointmentType.examination;

                foreach (RoomRecord room in Rooms)
                {
                    if (room.Id == appointment.Doctor.Ordination)
                    {
                        appointment.RoomRecord = room;
                    }
                }

                if (isDoctorAvailable(appointment.StartTime) && isPatientAvailable(appointment.Patient, appointment.StartTime))
                {
                    Appointments.Add(appointment);
                    appointmentRepository.SaveToFile(Appointments, "Appointments.json");
                }
                else if (!isDoctorAvailable(appointment.StartTime))
                {
                    MessageBox.Show("Nije moguce zakazati pregled u zadatom terminu - lekar je zauzet!");
                }
                else if (!isPatientAvailable(appointment.Patient, appointment.StartTime))
                {
                    MessageBox.Show("Nije moguce zakazati pregled u zadatom terminu - pacijent je zauzet!");
                }

                DoctorWindow doctorWindow = new DoctorWindow();
                doctorWindow.dataGridExaminations.Items.Refresh();
                doctorWindow.Show();

                this.Close();
            }
        }

        private bool isDoctorAvailable(DateTime dateAndTime)
        {
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment appointment in Appointments)
            {
                string drNameSurname = appointment.Doctor.Name + ' ' + appointment.Doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()) && appointment.StartTime.Equals(dateAndTime))
                {
                    return false;
                }
            }

            return true;
        }

        private bool isPatientAvailable(Patient patient, DateTime dateAndTime)
        {
            Appointments = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment appointment in Appointments)
            {
                if (appointment.Patient.Id == patient.Id && appointment.StartTime == dateAndTime)
                {
                    return false;
                }
            }

            return true;
        }

        private void specijalistiRadioBtn_Checked(object sender, RoutedEventArgs e)
        {

            Specialization specialization = new Specialization();
            List<string> specializatonNames = new List<string>();
            specializations = specialization.getSpecializations();

            foreach (Specialization spec in specializations)
            {
                specializatonNames.Add(spec.Name);
            }

            chooseSpecComboBox.ItemsSource = specializatonNames;
        }

        private void opstaPraksaRadioBtn_Checked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization.Name == " ")
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    doctorNameAndSurname.Add(dr);
                }
            }

            doctorsComboBox.ItemsSource = doctorNameAndSurname;
            chooseSpecComboBox.IsEnabled = false;
            chooseSpecComboBox.IsEditable = false;
        }

        private void opstaPraksaRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization.Name == " ")
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    doctorNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = doctorNameAndSurname;
            chooseSpecComboBox.IsEnabled = true;
            chooseSpecComboBox.IsEditable = true;
        }

        private void specijalistiRadioBtn_Unchecked(object sender, RoutedEventArgs e)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization.Name != " ")
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = specialistNameAndSurname;
        }

        private void jmbgTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            Patients = patientStorage.loadFromFile("PatientRecordFileStorage.json");

            foreach (Patient patient in Patients)
            {
                if (jmbgTxt.Text.Equals(patient.Id))
                {
                    healthCardNumberTxt.Text = patient.HealthCardNumber;
                }
            }

        }
        private void showDoctorOrdination()
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            foreach (Doctor doctor in Doctors)
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;

                if (drNameSurname.Equals(doctorsComboBox.SelectedItem.ToString()))
                {
                    roomTxt.Text = doctor.Ordination.ToString();
                }
            }
        }

        private void showDoctors(string specializationName)
        {
            Doctors = doctorStorage.loadFromFile("Doctors.json");
            string dr;

            foreach (Doctor doctor in Doctors)
            {
                if (doctor.Specialization.Name.Equals(specializationName))
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Add(dr);
                }
                else
                {
                    dr = doctor.Name + ' ' + doctor.Surname;
                    specialistNameAndSurname.Remove(dr);
                }
            }

            doctorsComboBox.ItemsSource = specialistNameAndSurname;
        }

        private void doctorsComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (doctorsComboBox.SelectedItem != null)
            {
                showDoctorOrdination();
            }
            else if (doctorsComboBox.SelectedItem == null)
            {
                roomTxt.Text = " ";
            }

        }

        private void chooseSpecComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            doctorsComboBox.ItemsSource = null;

            showDoctors(chooseSpecComboBox.SelectedItem.ToString());

        }
    }
}
