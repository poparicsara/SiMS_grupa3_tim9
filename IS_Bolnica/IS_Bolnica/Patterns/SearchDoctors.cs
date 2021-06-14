using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Patterns
{
    class SearchDoctors : SearchGridTemplate<Doctor>
    {
        private DoctorRepository doctorRepository = new DoctorRepository();

        public override bool ISearched(string text, Doctor entity)
        {
            return entity.Name.ToLower().Contains(text) ||
                   entity.Surname.ToLower().Contains(text) ||
                   entity.Username.ToLower().Contains(text) ||
                   entity.Id.ToLower().StartsWith(text);
        }

        public override List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }
    }
}
