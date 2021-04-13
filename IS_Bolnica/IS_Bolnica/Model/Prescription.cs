using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    class Prescription
    {
        public String MedicationName
        {
            get;
            set;
        }

        public String Diagnosis
        {
            get;
            set;
        }

        public Doctor Doctor
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Patient Patient
        {
            get;
            set;
        }
    }
}
