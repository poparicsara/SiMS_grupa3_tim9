using System;
using System.Collections.Generic;

namespace Model
{
    public class Patient : User
    {
        public List<string> Allergens { get; set; }

        public Patient()
        {
            
        }
    }
}