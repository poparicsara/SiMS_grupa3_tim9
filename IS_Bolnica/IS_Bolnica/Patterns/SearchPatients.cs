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
        private PatientRepository patientRepository = new PatientRepository();

        public override bool ISearched(string text, Patient entity)
        {
            return entity.Name.ToLower().Contains(text) ||
                   entity.Surname.ToLower().Contains(text) ||
                   entity.Id.ToLower().StartsWith(text) ||
                   entity.Username.ToLower().Contains(text);
        }

        public override List<Patient> GetAll()
        {
            return patientRepository.GetAll();
        }
    }
}
