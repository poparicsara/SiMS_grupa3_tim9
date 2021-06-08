using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Model;
using IS_Bolnica.PatientPages;
using Model;

namespace IS_Bolnica.Services
{
    public class AppointmentService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Appointment> examinations = new List<Appointment>();
        private List<Appointment> operations = new List<Appointment>();
        private UserService userService = new UserService();
        private PatientRepository patientRepository = new PatientRepository();
        private NotificationRepository notificationRepository = new NotificationRepository();

        public AppointmentService()
        {
            appointments = GetAppointments();
        }

        public void AddAppointment(Appointment appointment)
        {
            if (isAppointmentValid(appointment))
            {
                if (isAvailable(appointments, appointment))
                {
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                }
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            int index = FindAppointmentIndex(appointment);
            appointments.RemoveAt(index);
            appointmentRepository.SaveToFile(appointments, "Appointments.json");
        }

        public void EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            if (isAppointmentValid(newAppointment))
            {
                int indexOld = FindAppointmentIndex(oldAppointment);
                appointments.RemoveAt(indexOld);
                if (isAvailable(appointments, newAppointment))
                {
                    appointments.Add(newAppointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                }
                else
                {
                    appointments.Add(oldAppointment);
                    appointmentRepository.SaveToFile(appointments, "Appointments.json");
                }
            }
        }

        public List<Appointment> getExaminations()
        {
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == 0)
                {
                    examinations.Add(appointment);
                }
            }

            return examinations;
        }

        public List<Appointment> getOperations()
        {
            foreach (var appointment in appointments)
            {
                if (appointment.AppointmentType == AppointmentType.operation)
                {
                    operations.Add(appointment);
                }
            }

            return  operations;
        }

        public void RemovePatientsAppointments(Patient patient)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(patient);
            for (int i = 0; i < appointments.Count; i++)
            {
                foreach (var patientAppointment in patientAppointments)
                {
                    if (patientAppointment.Patient.Id.Equals(appointments[i].Patient.Id))
                    {
                        appointments.RemoveAt(i);
                    }
                }
            }
            appointmentRepository.SaveToFile(appointments, "Appointments.json");
        }

        private bool isAppointmentValid(Appointment appointment)
        {
            if (appointment.Room != null && appointment.Doctor != null && appointment.Patient != null)
            {
                return true;
            }
            return false;

        }

        public List<Appointment> FindPatientAppointments(Patient patient)
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            foreach (var appointment in appointments)
            {
                if (appointment.Patient.Id.Equals(patient.Id))
                {
                    patientAppointments.Add(appointment);
                }
            }

            return patientAppointments;

        }

        public Boolean checkAppointment(Appointment appointment)
        {
            DateTime now = DateTime.Now;
            string[] pom = now.ToString().Split(' ');
            string[] dateNow = pom[0].Split('/');

            string[] appointmentStartDateAndTime = appointment.StartTime.ToString().Split(' ');
            string[] appointmentDate = appointmentStartDateAndTime[0].Split('/');
            List<Patient> patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
            Patient loggedPatient = findPatientByUsername(PatientWindow.username_patient);

            if (Convert.ToInt32(dateNow[0]) > Convert.ToInt32(appointmentDate[0]))
            {
                loggedPatient.brojOcenjenihPregleda++;
                patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
                DeleteAppointment(appointment);
                return true;
            }
            else if (Convert.ToInt32(dateNow[0]) == Convert.ToInt32(appointmentDate[0]) && Convert.ToInt32(dateNow[1]) > Convert.ToInt32(appointmentDate[1]))
            {
                loggedPatient.brojOcenjenihPregleda++;
                patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
                DeleteAppointment(appointment);
                return true;
            }
            return false;
        }

        public Boolean sendEvaluationOfHospital()
        {
            Patient loggedPatient = findPatientByUsername(PatientWindow.username_patient);
            if (loggedPatient.brojOcenjenihPregleda % 7 == 0)
            {
                return true;
            }

            return false;
        }

        private int FindAppointmentIndex(Appointment appointment)
        {
            for (int i = 0; i < appointments.Count; i++)
            {
                if (appointment.StartTime.Equals(appointments[i].StartTime) &&
                    appointment.Patient.Id.Equals(appointments[i].Patient.Id))
                {
                    return i;
                }
            }

            return -1;
        }

        private bool isPatientFree(List<Appointment> appointments, Appointment appointment)
        {

            foreach (Appointment app in appointments)
            {
                if (app.Patient.Id == appointment.Patient.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    } else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    } else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        MessageBox.Show("Pacijent u ovom terminu ima već zakazan pregled");
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Room.Id == appointment.Room.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        MessageBox.Show("Soba " + appointment.Room.Id + "je zauzeta u izabranom terminu");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(List<Appointment> appointments, Appointment appointment)
        {
            foreach (Appointment app in appointments)
            {
                if (app.Doctor.Id == appointment.Doctor.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        MessageBox.Show("Doktor već ima zakazan termin u isto vreme!");
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isAvailable(List<Appointment> appointments, Appointment appointment)
        {
            if (isPatientFree(appointments, appointment) &&
                isRoomFree(appointments, appointment) &&
                isDoctorFree(appointments, appointment))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Appointment> GetAppointments()
        {
            return appointmentRepository.LoadFromFile("Appointments.json");
        }

        public List<Appointment> getDoctorsExaminations()
        {
            List<Appointment> doctorsExaminations = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                foreach (User user in userService.GetLoggedUsers())
                {
                    if (appointment.Doctor.Username.Equals(user.Username) && appointment.AppointmentType == 0)
                    {
                        doctorsExaminations.Add(appointment);
                    }
                }
            }
            return doctorsExaminations;
        }
        public List<Appointment> getDoctorsOperations()
        {
            List<Appointment> doctorsExaminations = new List<Appointment>();
            foreach (Appointment appointment in appointments)
            {
                foreach (User user in userService.GetLoggedUsers())
                {
                    if (appointment.Doctor.Username.Equals(user.Username) && appointment.AppointmentType == AppointmentType.operation)
                    {
                        doctorsExaminations.Add(appointment);
                    }
                }
            }
            return doctorsExaminations;
        }

        public void scheduleAppointment(Appointment appointment)
        {
            if (isDoctorAvailable(appointment) && isPatientAvailable(appointment))
            {
                appointments.Add(appointment);
                appointmentRepository.SaveToFile(appointments, "Appointments.json");
            }
            else
            {
                MessageBox.Show("Nije moguce zakazati termin!");
            }
        }
        private bool isDoctorAvailable(Appointment appointment)
        {
            foreach (Appointment scheduledAppointment in appointments)
            {
                if (scheduledAppointment.Doctor.Id.Equals(appointment.Doctor.Id))
                {
                    if (scheduledAppointment.StartTime.Equals(appointment.StartTime))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private bool isPatientAvailable(Appointment appointment)
        {
            foreach (Appointment scheduledAppointment in appointments)
            {
                if (scheduledAppointment.Patient.Id.Equals(appointment.Patient.Id))
                {
                    if (scheduledAppointment.StartTime.Equals(appointment.StartTime))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public Boolean processActions()
        {
            increaseActions();
            return checkActions();
        }

        private void increaseActions()
        {
            List<Patient> patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
            foreach (Patient patient in patients)
            {
                if (patient.Username.Equals(PatientWindow.username_patient))
                    patient.Akcije++;
            }

            patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
        }

        private Boolean checkActions()
        {
            Patient patient = findPatientByUsername(PatientWindow.username_patient);
            if (patient.Akcije >= 6)
            {
                Notification notification = new Notification { Title="Blokada", Content="Blokiran pacijent " + PatientWindow.loggedPatient.Name + 
                    " " + PatientWindow.loggedPatient.Surname + "!", Sender = UserType.patient, notificationType = NotificationType.secretory};
                addNotification(notification);
                return true;
            }
            return false;
        }

        private void addNotification(Notification newNotification) {
            List<Notification> notifications = notificationRepository.LoadFromFile("NotificationsFileStorage.json");
            Boolean posible = true;
            foreach (Notification notification in notifications) {
                if (newNotification.Content.Equals(notification.Content))
                    posible = false;
            }

            if (posible) {
                notifications.Add(newNotification);
                notificationRepository.SaveToFile(notifications, "NotificationsFileStorage.json");
            }
        }

        public Patient findPatientByUsername(string username)
        {
            List<Patient> patients = patientRepository.LoadFromFile("PatientRecordFileStorage.json");
            Patient returnPatient = new Patient();

            foreach (Patient patient in patients)
            {
                if (patient.Username.Equals(username))
                {
                    returnPatient = patient;
                }
            }

            return returnPatient;
        }

        public Boolean isSelectedDateFree(DateTime selectedDate, Doctor selectedDoctor)
        {
            List<Appointment> appointments = GetAppointments();

            foreach (Appointment appointment in appointments)
            {
                if (Convert.ToString(appointment.StartTime).Equals(selectedDate.ToString()) && selectedDoctor.Name.Equals(appointment.Doctor.Name) && selectedDoctor.Surname.Equals(appointment.Doctor.Surname))
                    return true;
            }

            return false;
        }

        public Appointment findSelectedPatientAppointment(int selectedIndex)
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));
            Appointment selectedAppointment = new Appointment();

            for (int i = 0; i < patientAppointments.Count; i++)
            {
                if (i == selectedIndex)
                    selectedAppointment = patientAppointments[i];
            }

            return selectedAppointment;
        }

        public Boolean checkDateOfAppointment(Appointment selectedAppointment)
        {
            DateTime now = DateTime.Now;
            string[] pom = now.AddDays(2).ToString().Split(' ');
            string[] dateNow = pom[0].Split('/');

            string[] appointmentStartDateAndTime = selectedAppointment.StartTime.ToString().Split(' ');
            string[] appointmentDate = appointmentStartDateAndTime[0].Split('/');

            if (Convert.ToInt32(dateNow[0]) == Convert.ToInt32(appointmentDate[0]))
            {
                if (Convert.ToInt32(dateNow[1]) < Convert.ToInt32(appointmentDate[1]))
                    return false;
                else
                    return true;
            }
            return false;
        }
    }
}
