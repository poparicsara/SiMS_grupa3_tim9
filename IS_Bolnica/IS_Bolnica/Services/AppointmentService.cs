using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IS_Bolnica.Model;
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

        public AppointmentService()
        {
            appointments = GetAppointments();
        }

        public void AddAppointment(Appointment appointment)
        {
            appointments = GetAppointments();
            if (isAppointmentValid(appointment))
            {
                if (IsAvailable(appointment))
                {
                    appointments.Add(appointment);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        public void DeleteAppointment(Appointment appointment)
        {
            appointments = GetAppointments();
            int index = FindAppointmentIndex(appointment);
            appointments.RemoveAt(index);
            appointmentRepository.SaveToFile(appointments);
        }

        public void EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            appointments = GetAppointments();
            if (isAppointmentValid(newAppointment))
            {
                int indexOld = FindAppointmentIndex(oldAppointment);
                appointments.RemoveAt(indexOld);
                if (IsAvailable(newAppointment))
                {
                    appointments.Add(newAppointment);
                    appointmentRepository.SaveToFile(appointments);
                }
                else
                {
                    appointments.Add(oldAppointment);
                    appointmentRepository.SaveToFile(appointments);
                }
            }
        }

        public List<Appointment> getExaminations()
        {
            appointments = GetAppointments();
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
            appointments = GetAppointments();
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
            appointments = GetAppointments();
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
            appointmentRepository.SaveToFile(appointments);
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
            appointments = GetAppointments();
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

        public List<Appointment> returnPatientAppointmentsAfterCheck()
        {
            List<Appointment> patientAppointments = FindPatientAppointments(findPatientByUsername(PatientWindow.username_patient));

            foreach (Appointment appointment in patientAppointments) { 
                
            }

            return patientAppointments;
        }

        private Boolean checkAppointment(Appointment appointment)
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
                sendEvaluationOfAppointment(appointment);
                return true;
            }
            else if (Convert.ToInt32(dateNow[0]) == Convert.ToInt32(appointmentDate[0]) && Convert.ToInt32(dateNow[1]) > Convert.ToInt32(appointmentDate[1]))
            {
                loggedPatient.brojOcenjenihPregleda++;
                patientRepository.SaveToFile(patients, "PatientRecordFileStorage.json");
                DeleteAppointment(appointment);
                sendEvaluationOfAppointment(appointment);
                return true;
            }
            return false;
        }

        public void sendEvaluationOfAppointment(Appointment appointment)
        {
            OcenjivanjePregleda op = new OcenjivanjePregleda(appointment);
            op.Show();
            sendEvaluationOfHospital();
        }

        private void sendEvaluationOfHospital()
        {
            Patient loggedPatient = findPatientByUsername(PatientWindow.username_patient);
            if (loggedPatient.brojOcenjenihPregleda % 7 == 0)
            {
                OcenjivanjeBolnice ob = new OcenjivanjeBolnice();
                ob.Show();
            }
        }

        private int FindAppointmentIndex(Appointment appointment)
        {
            appointments = GetAppointments();
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

        private bool isPatientFree(Appointment appointment)
        {
            appointments = GetAppointments();
            foreach (Appointment app in appointments)
            {
                if (app.Patient.Id == appointment.Patient.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    } else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    } else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        return false;
                    }
                }

            }

            return true;
        }

        private bool isRoomFree(Appointment appointment)
        {
            appointments = GetAppointments();
            foreach (Appointment app in appointments)
            {
                if (app.Room.Id == appointment.Room.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime < appointment.EndTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isDoctorFree(Appointment appointment)
        {
            appointments = GetAppointments();
            foreach (Appointment app in appointments)
            {
                if (app.Doctor.Id == appointment.Doctor.Id)
                {
                    if (app.StartTime <= appointment.StartTime && appointment.StartTime < app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime < appointment.EndTime && appointment.EndTime <= app.EndTime)
                    {
                        return false;
                    }
                    else if (app.StartTime >= appointment.StartTime && app.EndTime <= appointment.EndTime)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool IsAvailable(Appointment appointment)
        {
            if (isPatientFree(appointment) &&
                isRoomFree(appointment) &&
                isDoctorFree(appointment))
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
            return appointmentRepository.LoadFromFile();
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
                appointmentRepository.SaveToFile(appointments);
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
                patient.isBlocked = true;
                MessageBox.Show("Najvise 6 akcija nad pregledima mozete izvrsiti prilikom logovanja!");
                return true;
            }
            return false;
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
                {
                    MessageBox.Show("Ne mozete zakazati pregled jer je ovaj termin pregleda kod oznacenog doktora vec zauzet!");
                    return true;
                }
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
