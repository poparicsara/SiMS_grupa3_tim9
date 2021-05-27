using Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace IS_Bolnica.Secretary
{
    /// <summary>
    /// Interaction logic for AddUrgentOperationWindow.xaml
    /// </summary>
    public partial class AddUrgentOperationWindow : Window
    {
        private Specialization specialization = new Specialization();
        public List<String> Specializations { get; set; } = new List<String>();
        private List<Specialization> specializations;
        private Operation operation;
        private PatientRepository patientStorage = new PatientRepository();
        private List<Patient> patients = new List<Patient>();
        private Patient patient = new Patient();
        private GuestUserRepository guestStorage = new GuestUserRepository();
        private List<GuestUser> guestUsers = new List<GuestUser>();
        private GuestUser guestUser = new GuestUser();
        private List<RoomRecord> Rooms = new List<RoomRecord>();
        private RoomRepository roomStorage = new RoomRepository();
        private List<int> RoomNums = new List<int>();

        public AddUrgentOperationWindow()
        {
            InitializeComponent();
            //specializations = specialization.getSpecializations();
            //foreach (Specialization spec in specializations)
            //{
            //    Specializations.Add(spec.Name);
            //}
            //specializationBox.ItemsSource = Specializations;

            setSpecializationsBox();

            //Rooms = roomStorage.LoadFromFile("Sobe.json");
            //for (int i = 0; i < Rooms.Count; i++)
            //{
            //    if (Rooms[i].roomPurpose.Name == "Operaciona sala")
            //    {
            //        RoomNums.Add(Rooms[i].Id);
            //    }
            //}
            //operatiomRoomBox.ItemsSource = RoomNums;

            setRoomBox();
        }

        private void setSpecializationsBox()
        {
            specializations = specialization.getSpecializations();
            foreach (Specialization spec in specializations)
            {
                Specializations.Add(spec.Name);
            }
            specializationBox.ItemsSource = Specializations;
        }

        private void setRoomBox()
        {
            Rooms = roomStorage.loadFromFile("Sobe.json");
            for (int i = 0; i < Rooms.Count; i++)
            {
                if (Rooms[i].roomPurpose.Name == "Operaciona sala")
                {
                    RoomNums.Add(Rooms[i].Id);
                }
            }
            operatiomRoomBox.ItemsSource = RoomNums;

        }

        private void addGuestAccount(object sender, RoutedEventArgs e)
        {
            GuestUserAccount gua = new GuestUserAccount(sender);
            gua.Show();
            this.Close();
        }

        private Patient findPatient(string id)
        {
            Patient patien = new Patient();
            patients = patientStorage.LoadFromFile("PatientRecordFileStorage.json");

            foreach (Patient pat in patients)
            {
                if (pat.Id.Equals(id))
                {
                    patien = pat;
                }
            }

            return patien;

        }

        private GuestUser findGuest(string systemName)
        {
            GuestUser guest = new GuestUser();
            guestUsers = guestStorage.LoadFromFile("GuestUsersFile.json");

            foreach(GuestUser gUser in guestUsers)
            {
                if(gUser.SystemName.Equals(systemName))
                {
                    guest = gUser;
                }
            }

            return guest;
        }

        private void findSpecialization(string spec)
        {
            foreach(Specialization s in specializations)
            {
                if(s.Name.Equals(spec))
                {
                    specialization = s;
                }
            }
        }

        private void getOptions(object sender, RoutedEventArgs e)
        {
            if(patientIdBox.Text != null)
            {
                patient = findPatient(patientIdBox.Text);
            }
            else if(patientIdBox.Text == null && patientIdBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli id pacijenta");
                return;
            } 
            else if(systemNameBox.Text != null)
            {
                guestUser = findGuest(systemNameBox.Text);
            } 
            else if(systemNameBox.Text == null && systemNameBox.IsEnabled)
            {
                MessageBox.Show("Niste uneli sistemsko ime guest korisnika");
                return;
            }

            int satiMin = Convert.ToInt32(hourBox.Text);
            int min = Convert.ToInt32(minuteBox.Text);

            int duration = satiMin * 60 + min;

            operation = new Operation { DurationInMins = duration, GuestUser = guestUser, Patient = patient };
            findSpecialization(specializationBox.SelectedItem.ToString());

            UrgentOperationOptionsWindow uoow = new UrgentOperationOptionsWindow(operation, specialization);
            uoow.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ActionBarWindow abw = new ActionBarWindow();
            abw.Show();
            this.Close();
        }

        private void existableRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = true;
            systemNameBox.IsEnabled = false;
        }

        private void guestRButton_Checked(object sender, RoutedEventArgs e)
        {
            patientIdBox.IsEnabled = false;
            systemNameBox.IsEnabled = true;
        }
    }
}
