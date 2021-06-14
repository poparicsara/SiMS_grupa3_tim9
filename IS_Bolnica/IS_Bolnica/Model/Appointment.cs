using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Appointment
    {
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
        public int DurationInMins { get; set; }
        public GuestUser GuestUser { get; set; }
        public Room Room { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime PostponedDate { get; set; }
        public bool IsUrgent { get; set; }
        public AppointmentType AppointmentType { get; set; }
        public string YesNo { get; set; }
    }
}
