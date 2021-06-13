using System.Collections.Generic;
using System.Windows;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    class DoctorService
    {
        private DoctorRepository doctorRepository = new DoctorRepository();
        private List<Doctor> doctors = new List<Doctor>();
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private NotificationRepository notificationRepository = new NotificationRepository();
        private Shift newShift = new Shift();
        private Shift newShift2 = new Shift();
        private AppointmentService appointmentService = new AppointmentService();

        public DoctorService()
        {

        }

        public void AddShift(Shift shift)
        {
            if (!isShiftValid(shift)) return;
            if (isDoctorOnVacay(shift)) return;
            rescheduleShifts(shift);
            quitAppointmentsShift(shift);
            doctorRepository.AddShift(shift);
        }

        public void AddVacation(Vacation vacation)
        {
            isVacationValid(vacation);
            rescheduleShiftsVacation(vacation);
            quitAppointmentsVacation(vacation);
            doctorRepository.AddVacation(vacation);
        }

        public void DeleteShift(Shift shift)
        {
            int index = findShiftIndex(shift);
            doctorRepository.DeleteShift(index, shift.DoctorsId);
        }

        public void DeleteVacation(Vacation vacation)
        {
            int index = findVacationIndex(vacation);
            doctorRepository.DeleteVacation(index, vacation.DoctorsId);
        }

        private bool isDoctorOnVacay(Shift shift)
        {
            Doctor doctor = doctorRepository.FindById(shift.DoctorsId);
            var vacations = doctor.Vacations;
            foreach (var vacation in vacations)
            {
                if (shift.ShiftStartDate >= vacation.VacationStartDate && shift.ShiftEndDate >= vacation.VacationStartDate)
                {
                    return true;
                }
            }

            return false;
        }

        private bool isShiftValid(Shift shift)
        {
            Doctor doctor = doctorRepository.FindById(shift.DoctorsId);
            var shifts = doctor.Shifts;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (shifts[i].ShiftStartDate <= shift.ShiftStartDate && shifts[i].ShiftEndDate >= shift.ShiftEndDate && shift.ShiftType == shifts[i].ShiftType)
                {
                    return false;
                }
            }
                return true;
        }

        private bool isVacationValid(Vacation vacation)
        {
            Doctor doctor = doctorRepository.FindById(vacation.DoctorsId);
            var vacations = doctor.Vacations;
            for (int i = 0; i < vacations.Count; i++)
            {
                if (vacations[i].VacationStartDate <= vacation.VacationStartDate && vacations[i].VacationEndDate >= vacation.VacationEndDate )
                {
                    return false;
                }
            }
            return true;
        }

        private void rescheduleShifts(Shift shift)
        {
            Doctor doctor = doctorRepository.FindById(shift.DoctorsId);
            var shifts = doctor.Shifts;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (shifts[i].ShiftStartDate <= shift.ShiftStartDate && shifts[i].ShiftEndDate >= shift.ShiftEndDate)
                {
                    postponeShiftOneS(shift, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, shift.DoctorsId);
                    i--;
                }
                else if (shifts[i].ShiftStartDate >= shift.ShiftStartDate && shifts[i].ShiftEndDate <= shift.ShiftEndDate)
                {
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, shift.DoctorsId);
                    i--;
                }
                else if (shifts[i].ShiftStartDate >= shift.ShiftStartDate && shifts[i].ShiftStartDate <= shift.ShiftEndDate)
                { 
                    postponeShiftTwoS(shift, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, shift.DoctorsId);
                    i--;
                }
                else if (shifts[i].ShiftEndDate >= shift.ShiftStartDate && shifts[i].ShiftEndDate <= shift.ShiftEndDate)
                {
                    postponeShiftThreeS(shift, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, shift.DoctorsId);
                    i--;
                }
            }
        }

        private void rescheduleShiftsVacation(Vacation vacation)
        {
            Doctor doctor = doctorRepository.FindById(vacation.DoctorsId);
            var shifts = doctor.Shifts;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (shifts[i].ShiftStartDate <= vacation.VacationStartDate && shifts[i].ShiftEndDate >= vacation.VacationEndDate)
                {
                    postponeShiftOne(vacation, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, vacation.DoctorsId);
                    i--;
                }
                else if(shifts[i].ShiftStartDate >= vacation.VacationStartDate && shifts[i].ShiftEndDate <= vacation.VacationEndDate )
                {
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, vacation.DoctorsId);
                    i--;
                }
                else if(shifts[i].ShiftStartDate >= vacation.VacationStartDate && shifts[i].ShiftStartDate <= vacation.VacationEndDate)
                {
                    postponeShiftTwo(vacation, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, vacation.DoctorsId);
                    i--;
                }
                else if (shifts[i].ShiftEndDate >= vacation.VacationStartDate && shifts[i].ShiftEndDate <= vacation.VacationEndDate)
                {
                    postponeShiftThree(vacation, shifts[i]);
                    shifts.RemoveAt(i);
                    doctorRepository.DeleteShift(i, vacation.DoctorsId);
                    i--;
                }
            }
        }

        private void quitAppointmentsVacation(Vacation vacation)
        {
            List<string> ids;
            List<Appointment> doctorAppointments = findDoctorAppointments(vacation.DoctorsId);
            for (int i = 0; i < doctorAppointments.Count; i++)
            {
                if (doctorAppointments[i].StartTime > vacation.VacationStartDate && doctorAppointments[i].EndTime < vacation.VacationEndDate)
                {
                    ids = new List<string>();
                    ids.Add(doctorAppointments[i].Patient.Id);
                    string content = "Obavestavamo vas da vam je otkazan pregled koji je planiran " + doctorAppointments[i].StartTime.ToString() + "Molimo Vas da nas kontaktirate kako bismo se dogovorili o ponovnom zakazivanju istog!";
                    Notification notification = new Notification(title:"Pažnja", content, notificationType: NotificationType.specific, ids);
                    notificationRepository.Add(notification);
                    int index = appointmentService.FindAppointmentIndex(doctorAppointments[i]);
                    appointmentRepository.Delete(index);
                }
            }
        }

        private void quitAppointmentsShift(Shift shift)
        {
            List<string> ids;
            List<Appointment> doctorAppointments = findDoctorAppointments(shift.DoctorsId);
            for (int i = 0; i < doctorAppointments.Count; i++)
            {
                if (doctorAppointments[i].StartTime > shift.ShiftStartDate && doctorAppointments[i].EndTime < shift.ShiftEndDate)
                {
                    ids = new List<string>();
                    ids.Add(doctorAppointments[i].Patient.Id);
                    string content = "Obavestavamo vas da vam je otkazan pregled koji je planiran " + doctorAppointments[i].StartTime.ToString() + "Molimo Vas da nas kontaktirate kako bismo se dogovorili o ponovnom zakazivanju istog!";
                    Notification notification = new Notification(title: "Pažnja", content, notificationType: NotificationType.specific, ids);
                    notificationRepository.Add(notification);
                    int index = appointmentService.FindAppointmentIndex(doctorAppointments[i]);
                    appointmentRepository.Delete(index);
                }
            }
        }

        private void postponeShiftOneS(Shift addedShift, Shift oldShift)
        {
            newShift.ShiftStartDate = oldShift.ShiftStartDate;
            newShift.ShiftType = oldShift.ShiftType;
            newShift.DoctorsId = oldShift.DoctorsId;
            newShift.ShiftEndDate = addedShift.ShiftStartDate;
            doctorRepository.AddShift(newShift);
            newShift2.ShiftStartDate = addedShift.ShiftEndDate;
            newShift2.ShiftEndDate = oldShift.ShiftEndDate;
            newShift2.ShiftType = oldShift.ShiftType;
            newShift2.DoctorsId = oldShift.DoctorsId;
            doctorRepository.AddShift(newShift2);

        }

        private void postponeShiftTwoS(Shift addedShift, Shift oldShift)
        {
            newShift.DoctorsId = oldShift.DoctorsId;
            newShift.ShiftEndDate = oldShift.ShiftEndDate;
            newShift.ShiftType = oldShift.ShiftType;
            newShift.ShiftStartDate = addedShift.ShiftEndDate;
            doctorRepository.AddShift(newShift);
        }

        private void postponeShiftThreeS(Shift addedShift, Shift oldShift)
        {
            newShift.ShiftStartDate = oldShift.ShiftStartDate;
            newShift.DoctorsId = oldShift.DoctorsId;
            newShift.ShiftType = oldShift.ShiftType;
            newShift.ShiftEndDate = addedShift.ShiftStartDate;
            doctorRepository.AddShift(newShift);
        }

        private void postponeShiftOne(Vacation vacation, Shift shift)
        {
            newShift.ShiftStartDate = shift.ShiftStartDate;
            newShift.DoctorsId = shift.DoctorsId;
            newShift.ShiftType = shift.ShiftType;
            newShift.ShiftEndDate = vacation.VacationStartDate;
            doctorRepository.AddShift(newShift);
            newShift2.ShiftStartDate = vacation.VacationEndDate;
            newShift2.ShiftEndDate = shift.ShiftEndDate;
            newShift2.ShiftType = shift.ShiftType;
            newShift2.DoctorsId = shift.DoctorsId;
            doctorRepository.AddShift(newShift2);
        }

        private void postponeShiftTwo(Vacation vacation, Shift shift)
        {
            newShift.DoctorsId = shift.DoctorsId;
            newShift.ShiftEndDate = shift.ShiftEndDate;
            newShift.ShiftType = shift.ShiftType;
            newShift.ShiftStartDate = vacation.VacationEndDate;
            doctorRepository.AddShift(newShift);
        }

        private void postponeShiftThree(Vacation vacation, Shift shift)
        {
            newShift.ShiftStartDate = shift.ShiftStartDate;
            newShift.DoctorsId = shift.DoctorsId;
            newShift.ShiftType = shift.ShiftType;
            newShift.ShiftEndDate = vacation.VacationStartDate;
            doctorRepository.AddShift(newShift);
        }

        public List<string> GetDoctorNamesList()
        {
            List<string> docNames = new List<string>();
            doctors = doctorRepository.GetAll();
            for (int i = 0; i < doctors.Count; i++)
            {
                docNames.Add(doctors[i].Name + " " + doctors[i].Surname);
            }
            return docNames;
        }

        /*public List<Doctor> GetSearchedDoctors(string text)
        {
            doctors = doctorRepository.GetAll();
            List<Doctor> searchedDoctors = new List<Doctor>();
            foreach (Doctor doctor in doctors)
            {
                if (ISearched(text, doctor))
                {
                    searchedDoctors.Add(doctor);
                }
            }

            return searchedDoctors;
        }

        private static bool ISearched(string text, Doctor d)
        {
            return d.Name.ToLower().Contains(text) ||
                   d.Surname.ToLower().Contains(text) ||
                   d.Username.ToLower().Contains(text) ||
                   d.Id.ToLower().StartsWith(text);
        }*/

        public Doctor FindDoctorByName(string drNameSurname)
        {
            Doctor doctor = new Doctor();
            List<Doctor> doctors = doctorRepository.GetAll();
            foreach (Doctor dr in doctors)
            {
                string doctorsNameAndSurname = dr.Name + ' ' + dr.Surname;
                if (doctorsNameAndSurname.Equals(drNameSurname))
                {
                    doctor = dr;
                }
            }

            return doctor;
        }

        public int ShowDoctorsOrdination(string doctorsNameSurname)
        {
            int ordinationNumber = 0;
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                string drNameSurname = doctor.Name + ' ' + doctor.Surname;
                if (drNameSurname.Equals(doctorsNameSurname))
                {
                    ordinationNumber = doctor.Ordination;
                }
            }

            return ordinationNumber;
        }


        public List<string> GetSpecialistsNameSurname()
        {
            List<string> specialistsNameSurname = new List<string>();
            foreach (Doctor doctor in doctorRepository.GetAll())
            {
                if (doctor.Specialization != null)
                {
                    specialistsNameSurname.Add(doctor.Name + ' ' + doctor.Surname);
                }
            }
            return specialistsNameSurname;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctorRepository.GetAll();
        }

        public List<string> GetDoctorNamesWithSpecialization()
        {
            List<string> docNames = new List<string>();
            doctors = doctorRepository.GetAll();

            foreach (Doctor doctor in doctors)
            {
                docNames.Add(doctor.Name + " " + doctor.Surname + "(" + doctor.Specialization.Name + ")");
            }

            return docNames;
        }

        private List<Appointment> findDoctorAppointments(string id)
        {
            List<Appointment> allAppointments = appointmentRepository.GetAll();
            List<Appointment> doctorsAppointments = new List<Appointment>();
            foreach (var appointment in allAppointments)
            {
                if (appointment.Doctor.Id.Equals(id))
                {
                    doctorsAppointments.Add(appointment);
                }
            }

            return doctorsAppointments;
        }

        private int findShiftIndex(Shift shift)
        {
            Doctor doctor = doctorRepository.FindById(shift.DoctorsId);
            var shifts = doctor.Shifts;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (shift.ShiftEndDate.Equals(shifts[i].ShiftEndDate) && shift.ShiftStartDate.Equals(shifts[i].ShiftStartDate))
                {
                    return i;
                }
            }

            return -1;
        }

        private int findVacationIndex(Vacation vacation)
        {
            Doctor doctor = doctorRepository.FindById(vacation.DoctorsId);
            var shifts = doctor.Vacations;
            for (int i = 0; i < shifts.Count; i++)
            {
                if (vacation.VacationEndDate.Equals(shifts[i].VacationEndDate) && vacation.VacationStartDate.Equals(shifts[i].VacationStartDate))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
