using System;
using System.ComponentModel;

namespace Model
{
    public class Examination : INotifyPropertyChanged
    {
        private Boolean isPayed = false;
        private Evaluation evaluation;
        private int durationInMinutes;
        private DateTime date;
        private Patient patient;
        public Doctor doctor;
        public Secretary secretary;

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