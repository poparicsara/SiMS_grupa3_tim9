

using System;
using System.ComponentModel;

namespace Model
{
    public class Examination
    {
        public Boolean isPayed { get; set; }
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }
            set
            {
                if (value != date)
                {
                    date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public Patient Patient
        {
            get
            {
                return patient;
            }
            set
            {
                if (value != patient)
                {
                    patient = value;
                    OnPropertyChanged("Patient");
                }
            }
        }


        public String NameSurname
        {
            get;
            set;
        }

        public String RoomName
        {
            get;
            set;
        }

    }
}