using IS_Bolnica.Model;
using System;
using System.Collections.Generic;


namespace Model
{
    public class Patient : User
    {
        public List<string> Allergens { get; set; }
        public double Debit { get; set; }

        //public Examination[] examination;
        public List<Examination> examinations { get; set; }

        public Patient()
        {

        }

        public String HealthCardNumber
        {
            get;
            set;
        }

        public List<Anamnesis> Anamneses
        {
            get;
            set;
        }
    }
}