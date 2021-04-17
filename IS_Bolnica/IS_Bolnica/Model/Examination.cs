using System;

namespace Model
{
    public class Examination
    {
        public Boolean isPayed  { get; set; }
        public Evaluation evaluation { get; set; }
        public int durationInMinutes { get; set; }

    public Boolean Paying()
        {
            throw new NotImplementedException();
        }

        public Boolean Scheduling()
        {
            throw new NotImplementedException();
        }

        public Boolean Rescheduling(DateTime oldDate, DateTime newDate)
        {
            throw new NotImplementedException();
        }

        public DateTime date { get; set; }
        public Patient patient { get; set; }
        public Doctor doctor { get; set; }
        public Secretary secretary { get; set; }

        /// <summary>
        /// Property for Secretary
        /// </summary>
        /// <pdGenerated>Default opposite class property</pdGenerated>
        public Secretary Secretary
        {
            get
            {
                return secretary;
            }
            set
            {
                this.secretary = value;
            }
        }

    }
}