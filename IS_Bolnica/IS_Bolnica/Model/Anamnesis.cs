using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS_Bolnica.Model
{
    public class Anamnesis
    {
        public String Diagnosis
        {
            get;
            set;
        }

        public String Symptoms
        {
            get;
            set;
        }

        public Patient Patient
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

    }
}
