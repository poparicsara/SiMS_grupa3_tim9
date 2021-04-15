using System;

namespace Model
{
    public class Address
    {
        public string Street { get; set; }
        public int NumberOfBuilding { get; set; }
        public int Floor { get; set; }
        public int Apartment { get; set; }

        public City City { get; set; }

        public string Street
        {
            get;
            set;
        }

    }
}