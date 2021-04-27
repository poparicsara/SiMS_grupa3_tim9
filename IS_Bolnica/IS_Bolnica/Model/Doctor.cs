using System;
using System.Collections.Generic;

namespace Model
{
    public class Doctor : Employee
    {
        public Specialization specialization;

        public static implicit operator List<object>(Doctor v)
        {
            throw new NotImplementedException();
        }
    }
}