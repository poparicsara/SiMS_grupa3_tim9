using IS_Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Services
{
    class ReportService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        public ReportService() { }

        public List<Appointment> getAllAppointmentsOfPatient()
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            List<Appointment> appointments = appointmentRepository.LoadFromFile("Appointments.json");

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Patient.Id.Equals(PatientWindow.loggedPatient.Id))
                    patientAppointments.Add(appointment);
            }

            return patientAppointments;
        }

        public List<Report> getItemsForReport(String startDate, String endDate) {
            List<Report> reportList = new List<Report>();
            List<Appointment> allAppointmentsAndOperations = getAllAppointmentsOfPatient();

            foreach (Appointment appointment in allAppointmentsAndOperations) {
                if (appointment.AppointmentType.Equals("examination")) {
                    if (appointment.StartTime.Month == getMonth(startDate) && appointment.StartTime.Month < getMonth(endDate))
                    {
                        if (appointment.StartTime.Day >= getDay(startDate))
                        {
                            Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Pregled", NumOfRoom = appointment.Room.Id };
                            reportList.Add(report);
                        }
                    }
                    else if (appointment.StartTime.Month > getMonth(startDate) && appointment.StartTime.Month == getMonth(endDate)) {
                        if (appointment.StartTime.Day <= getDay(endDate))
                        {
                            Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Pregled", NumOfRoom = appointment.Room.Id };
                            reportList.Add(report);
                        }
                    }
                    else if (appointment.StartTime.Month > getMonth(startDate) && appointment.StartTime.Month < getMonth(endDate))
                    {
                        Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Pregled", NumOfRoom = appointment.Room.Id };
                        reportList.Add(report);
                    }
                } else {
                    if (appointment.StartTime.Month == getMonth(startDate) && appointment.StartTime.Month < getMonth(endDate))
                    {
                        if (appointment.StartTime.Day >= getDay(startDate))
                        {
                            Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Operacija", NumOfRoom = appointment.Room.Id };
                            reportList.Add(report);
                        }
                    }
                    else if (appointment.StartTime.Month > getMonth(startDate) && appointment.StartTime.Month == getMonth(endDate))
                    {
                        if (appointment.StartTime.Day <= getDay(endDate))
                        {
                            Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Operacija", NumOfRoom = appointment.Room.Id };
                            reportList.Add(report);
                        }
                    }
                    else if (appointment.StartTime.Month > getMonth(startDate) && appointment.StartTime.Month < getMonth(endDate))
                    {
                        Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Operacija", NumOfRoom = appointment.Room.Id };
                        reportList.Add(report);
                    }
                }
            }

            return reportList;
        }

        public int getDay(String date) {
            String[] partsOfDate = date.Split('/');

            return Convert.ToInt32(partsOfDate[1]);
        }

        public int getMonth(String date) {
            String[] partsOfDate = date.Split('/');

            return Convert.ToInt32(partsOfDate[0]);
        }
    }
}
