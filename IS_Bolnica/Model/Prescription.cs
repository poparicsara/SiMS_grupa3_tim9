using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Prescription
    {
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

        public Therapy Therapy
        {
            get;
            set;
        }

        public Anamnesis Anamnesis
        {
            get;
            set;
        }
    }
}
