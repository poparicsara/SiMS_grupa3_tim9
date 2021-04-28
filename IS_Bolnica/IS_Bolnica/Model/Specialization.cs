using System;
using System.Collections.Generic;

namespace Model
{
    public class Specialization
    {
        public String Name;

        public List<Specialization> getSpecializations()
        {
            List<Specialization> specializations = new List<Specialization>();

            Specialization s1 = new Specialization { Name = "Alergologija i imunologija" };
            specializations.Add(s1);
            Specialization s2 = new Specialization { Name = "Anesteziologija" };
            specializations.Add(s2);
            Specialization s3 = new Specialization { Name = "Dermatologija" };
            specializations.Add(s3);
            Specialization s4 = new Specialization { Name = "Radiologija - dijagnostika" };
            specializations.Add(s4);
            Specialization s5 = new Specialization { Name = "Porodièna medicina" };
            specializations.Add(s5);
            Specialization s6 = new Specialization { Name = "Interna medicina" };
            specializations.Add(s6);
            Specialization s7 = new Specialization { Name = "Medicinska genetika" };
            specializations.Add(s7);
            Specialization s8 = new Specialization { Name = "Neurologija" };
            specializations.Add(s8);
            Specialization s9 = new Specialization { Name = "Nuklearna medicina" };
            specializations.Add(s9);
            Specialization s10 = new Specialization { Name = "Akušerstvo i ginekologija" };
            specializations.Add(s10);
            Specialization s11 = new Specialization { Name = "Oftalmologija" };
            specializations.Add(s11);
            Specialization s12 = new Specialization { Name = "Patologija" };
            specializations.Add(s12);
            Specialization s13 = new Specialization { Name = "Pedijatrija" };
            specializations.Add(s13);
            Specialization s14 = new Specialization { Name = "Fizikalna medicina i rehabilitacija" };
            specializations.Add(s14);
            Specialization s15 = new Specialization { Name = "Psihijatrija" };
            specializations.Add(s15);
            Specialization s16 = new Specialization { Name = "Hirurgija" };
            specializations.Add(s16);
            Specialization s17 = new Specialization { Name = "Urologija" };
            specializations.Add(s17);
            Specialization s18 = new Specialization { Name = "Ortopedija" };
            specializations.Add(s18);

            return specializations;
        }

    }
}