using System;
using System.Collections.Generic;
using IS_Bolnica.Model;

namespace Model
{
    public class Doctor : Employee
    {
        public Specialization Specialization { get; set; }
        public int Ordination { get; set; }
        public List<Shift> Shifts { get; set; }
        public List<Vacation> Vacations { get; set; }
    }
}