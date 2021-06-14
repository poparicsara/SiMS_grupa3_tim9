﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Model
{
    public class Report
    {
        public DateTime StartTime { get; set; }
        public Doctor Doctor { get; set; }
        public String TypeOfAppointment { get; set; }
        public int NumOfRoom { get; set; }
    }
}
