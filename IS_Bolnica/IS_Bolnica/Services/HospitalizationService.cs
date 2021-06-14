using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class HospitalizationService
    {
        private HospitalizationRepository hospitalizationRepository = new HospitalizationRepository();
        private List<Hospitalization> hospitalizations = new List<Hospitalization>();

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
    }
}
