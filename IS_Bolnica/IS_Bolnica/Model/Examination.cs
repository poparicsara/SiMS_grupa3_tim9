using System;

namespace Model
{
    public class Examination
    {
        private Boolean isPayed = false;
        private Evaluation evaluation;
        private int durationInMinutes;

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

        public DateTime date;

        public Patient patient;
        public Doctor doctor;
        public Secretary secretary;

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