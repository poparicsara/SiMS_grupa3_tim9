namespace Model
{
    public class Operation
    {
        public RoomRecord roomRecord;
        public System.Collections.Generic.List<Doctor> doctor;

        public System.Collections.Generic.List<Doctor> Doctor
        {
            get
            {
                if (doctor == null)
                    doctor = new System.Collections.Generic.List<Doctor>();
                return doctor;
            }
            set
            {
                RemoveAllDoctor();
                if (value != null)
                {
                    foreach (Doctor oDoctor in value)
                        AddDoctor(oDoctor);
                }
            }
        }

        public void AddDoctor(Doctor newDoctor)
        {
            if (newDoctor == null)
                return;
            if (this.doctor == null)
                this.doctor = new System.Collections.Generic.List<Doctor>();
            if (!this.doctor.Contains(newDoctor))
                this.doctor.Add(newDoctor);
        }

        public void RemoveDoctor(Doctor oldDoctor)
        {
            if (oldDoctor == null)
                return;
            if (this.doctor != null)
                if (this.doctor.Contains(oldDoctor))
                    this.doctor.Remove(oldDoctor);
        }

        public void RemoveAllDoctor()
        {
            if (doctor != null)
                doctor.Clear();
        }
        public Patient patient;

    }
}