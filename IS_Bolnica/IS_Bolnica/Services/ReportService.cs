using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class ReportService
    {
        private AppointmentRepository appointmentRepository = new AppointmentRepository();
        private List<Appointment> appointments = new List<Appointment>();
        private List<Appointment> roomAppointments;
        private List<Appointment> reportAppointments;

        public ReportService()
        {

        }

        public List<Appointment> GetAppointmentsForReport(ReportData reportData)
        {
            reportAppointments = new List<Appointment>();
            foreach (var appointment in GetAppointmentsOfRoom(reportData))
            {
                if (appointment.StartTime > reportData.DateFrom && appointment.EndTime < reportData.DateTo)
                {
                    reportAppointments.Add(appointment);
                }
            }

            return reportAppointments;
        }

        private List<Appointment> GetAppointmentsOfRoom(ReportData reportData)
        {
            roomAppointments = new List<Appointment>();
            appointments = appointmentRepository.GetAll();
            foreach (var appointment in appointments)
            {
                if (appointment.Room.Id.Equals(reportData.RoomId))
                {
                    roomAppointments.Add(appointment);
                }
            }

            return roomAppointments;
        }

        public List<Appointment> getAllAppointmentsOfPatient()
        {
            List<Appointment> patientAppointments = new List<Appointment>();
            List<Appointment> appointments = appointmentRepository.GetAll();

            foreach (Appointment appointment in appointments)
            {
                if (appointment.Patient.Id.Equals(PatientWindow.loggedPatient.Id))
                    patientAppointments.Add(appointment);
            }

            return patientAppointments;
        }

        public List<Report> getItemsForReport(String startDate, String endDate)
        {
            List<Report> reportList = new List<Report>();
            List<Appointment> allAppointmentsAndOperations = getAllAppointmentsOfPatient();

            foreach (Appointment appointment in allAppointmentsAndOperations)
            {
                if (appointment.AppointmentType.Equals("examination"))
                {
                    if (appointment.StartTime.Month == getMonth(startDate) && appointment.StartTime.Month < getMonth(endDate))
                    {
                        if (appointment.StartTime.Day >= getDay(startDate))
                        {
                            Report report = new Report { StartTime = appointment.StartTime, Doctor = appointment.Doctor, TypeOfAppointment = "Pregled", NumOfRoom = appointment.Room.Id };
                            reportList.Add(report);
                        }
                    }
                    else if (appointment.StartTime.Month > getMonth(startDate) && appointment.StartTime.Month == getMonth(endDate))
                    {
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
                }
                else
                {
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

        public int getDay(String date)
        {
            String[] partsOfDate = date.Split('/');

            return Convert.ToInt32(partsOfDate[1]);
        }

        public int getMonth(String date)
        {
            String[] partsOfDate = date.Split('/');

            return Convert.ToInt32(partsOfDate[0]);
        }


    }
}
