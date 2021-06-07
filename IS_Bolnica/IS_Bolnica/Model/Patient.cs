using IS_Bolnica;
using IS_Bolnica.Model;
using System;
using System.Collections.Generic;


namespace Model
{
    public class Patient : User
    {
        public List<string> Allergens { get; set; }
        public List<Examination> examinations { get; set; }
        public int Akcije { get; set; }
        public int brojOcenjenihPregleda { get; set; }
        public Gender Gender { get; set; }
        public bool isBlocked { get; set; }

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

        public List<Ingredient> Ingredients 
        { 
            get; 
            set;
        }
    }
}