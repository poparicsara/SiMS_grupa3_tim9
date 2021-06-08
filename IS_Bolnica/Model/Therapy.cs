using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Therapy
    {
        public DateTime StartDate
        {
            get;
            set;
        }

        public String MedicationName
        {
            get;
            set;
        }

        public int Dose
        {
            get;
            set;
        }
    }
}
