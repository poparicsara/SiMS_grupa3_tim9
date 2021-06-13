using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.Patterns
{
    class SearchPatients : SearchGridTemplate<Patient>
    {
        private List<Patient> patients = new List<Patient>();
        private PatientRepository patientRepository = new PatientRepository();

        public override bool ISearched(string text, Patient entity)
        {
            return entity.Name.ToLower().Contains(text) ||
                   entity.Surname.ToLower().Contains(text) ||
                   entity.Id.ToLower().StartsWith(text) ||
                   entity.Username.ToLower().Contains(text);
        }

        public override List<Patient> GetSearchedEntities(string text)
        {
            patients = patientRepository.GetAll();
            List<Patient> searchedPatients = new List<Patient>();
            foreach (Patient patient in patients)
            {
                if (ISearched(text, patient))
                {
                    searchedPatients.Add(patient);
                }
            }

            return searchedPatients;
        }
    }
}
