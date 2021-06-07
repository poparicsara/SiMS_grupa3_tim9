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
            appointments = appointmentRepository.LoadFromFile();
            foreach (var appointment in appointments)
            {
                if (appointment.Room.Id.Equals(reportData.RoomId))
                {
                    roomAppointments.Add(appointment);
                }
            }

            return roomAppointments;
        }


    }
}
