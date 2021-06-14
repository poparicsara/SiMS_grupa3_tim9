using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class HospitalizationService
    {
        private HospitalizationRepository hospitalizationRepository = new HospitalizationRepository();
        private List<Hospitalization> hospitalizations = new List<Hospitalization>();
        private RenovationRepository renovationRepository = new RenovationRepository();
        private MergingRepository mergingRepository = new MergingRepository();
        private SeparationRepository separationRepository = new SeparationRepository();

        public HospitalizationService()
        {
            hospitalizations = GetAllHospitalizedPatients();
        }

        public void UpdateHospitalization(Hospitalization updatedHospitalization, int index)
        {
            hospitalizationRepository.Update(index, updatedHospitalization);
        }

        public int GetIndexOfHospitalization(Hospitalization selectedHospitalization)
        {
            int index = 0;
            foreach (Hospitalization hospitalization in hospitalizations)
            {
                if (hospitalization.Patient.Id.Equals(selectedHospitalization.Patient.Id) && 
                    hospitalization.StartDate.Equals(selectedHospitalization.StartDate))
                {
                    break;
                }

                index++;
            }

            return index;
        }

        public int GetNumberOfPatientsInRoom(int roomId)
        {
            int numberOfPatients = 0;
            foreach (Hospitalization hospitalization in hospitalizations)
            {
                if (hospitalization.Room.Id.Equals(roomId))
                {
                    numberOfPatients++;
                }
            }
            return numberOfPatients;

        }

        public void AddHospitalization(Hospitalization newHospitalization)
        {
            hospitalizationRepository.Add(newHospitalization);
        }

        public List<Hospitalization> GetAllHospitalizedPatients()
        {
            return hospitalizationRepository.GetAll();
        }

        public bool IsHospitalizationBetweenAnyRenovation(Hospitalization hospitalization)
        {
            if (CheckMergings(hospitalization)) return true;

            if (CheckRenovations(hospitalization)) return true;

            if (CheckSeparations(hospitalization)) return true;

            return false;
        }

        private bool CheckSeparations(Hospitalization hospitalization)
        {
            foreach (var s in separationRepository.GetAll())
            {
                if (s.Room.Id == hospitalization.Room.Id)
                {
                    Renovation r = GetRenovationFromSeparation(s);
                    if (IsStartDateInRenovationPeriod(hospitalization, r) || IsEndDateInRenovationPeriod(hospitalization, r))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckMergings(Hospitalization hospitalization)
        {
            foreach (var m in mergingRepository.GetAll())
            {
                if (m.Room1.Id == hospitalization.Room.Id)
                {
                    Renovation r1 = GetRenovationFromMerging(m, m.Room1);
                    if (IsStartDateInRenovationPeriod(hospitalization, r1) || IsEndDateInRenovationPeriod(hospitalization, r1))
                    {
                        return true;
                    }
                }

                if (m.Room2.Id == hospitalization.Room.Id)
                {
                    Renovation r2 = GetRenovationFromMerging(m, m.Room2);
                    if (IsStartDateInRenovationPeriod(hospitalization, r2) || IsEndDateInRenovationPeriod(hospitalization, r2))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private bool CheckRenovations(Hospitalization hospitalization)
        {
            foreach (var r in renovationRepository.GetAll())
            {
                if (r.Room.Id == hospitalization.Room.Id)
                {
                    if (IsStartDateInRenovationPeriod(hospitalization, r) || IsEndDateInRenovationPeriod(hospitalization, r))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private Renovation GetRenovationFromMerging(Merging merging, Room room)
        {
            string start = merging.StartDate + " " + 0 + ":" + 0;
            DateTime fullStartDate = Convert.ToDateTime(start);
            string end = merging.EndDate + " " + merging.Hour + ":" + merging.Minute;
            DateTime fullEndDate = Convert.ToDateTime(end);
            Renovation r = new Renovation { Room = room, StartDate = fullStartDate, EndDate = fullEndDate };
            return r;
        }

        private Renovation GetRenovationFromSeparation(Separation separation)
        {
            string start = separation.StartDate + " " + 0 + ":" + 0;
            DateTime fullStartDate = Convert.ToDateTime(start);
            string end = separation.EndDate + " " + separation.Hour + ":" + separation.Minute;
            DateTime fullEndDate = Convert.ToDateTime(end);
            Renovation r = new Renovation { Room = separation.Room, StartDate = fullStartDate, EndDate = fullEndDate };
            return r;
        }

        private bool IsStartDateInRenovationPeriod(Hospitalization hospitalization, Renovation renovation)
        {
            return hospitalization.StartDate >= renovation.StartDate && hospitalization.StartDate <= renovation.EndDate;
        }

        private bool IsEndDateInRenovationPeriod(Hospitalization hospitalization, Renovation renovation)
        {
            return hospitalization.EndDate >= renovation.StartDate && hospitalization.EndDate <= renovation.EndDate;
        }
    }
}
