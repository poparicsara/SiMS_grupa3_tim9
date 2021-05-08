using System;
using System.Collections.Generic;

namespace Model
{
    public class Operation
    {
        //  private RoomRecord roomRecord;
        //private Patient patient;
        public Doctor doctor { get; set; }
        public int DurationInMins { get; set; }
        public GuestUser GuestUser { get; set; }

        public List<Doctor> Doctor
        {
            get;
            /*{
                if (Doctor == null)
                    Doctor = new List<Doctor>();
                return Doctor;
            }*/
            set;
            /*{
                RemoveAllDoctor();
                if (value != null)
                {
                    foreach (Doctor oDoctor in value)
                        AddDoctor(oDoctor);
                }
            }*/
        }

        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.Doctor == null)
                this.Doctor = new System.Collections.Generic.List<Doctor>();
            if (!this.Doctor.Contains(newDoctor))
                this.Doctor.Add(newDoctor);
        }

        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.Doctor != null)
                if (this.Doctor.Contains(oldDoctor))
                    this.Doctor.Remove(oldDoctor);
        }

        public void RemoveAllDoctor()
        {
            if (Doctor != null)
                Doctor.Clear();
        }

        public DateTime Date
        {
            get;
            set;
        }

        public Patient Patient
        {
            get;
            set;
        }

        public RoomRecord RoomRecord
        {
            get;
            set;
        }

        public bool IsUrgent
        {
            get;
            set;
        }

        public DateTime endTime
        {
            get;
            set;
        }

        public DateTime PosponedDate
        { 
            get; 
            set; 
        }
    }
}