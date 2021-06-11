using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace IS_Bolnica.IRepository
{
    interface IPatientRepository : IGenericRepository<Patient, string>
    {
        Patient FindPatientById(string id);
        void UnblockPatient(Patient patient);
        List<Patient> GetBlockPatients();
        bool PatientExists(Patient patient);
        bool PatientIdExists(string id);
        int FindPatientIndex(Patient patient);
        void SetPatientAllergents(List<Ingredient> ingredients, string id);
        List<Patient> GetSearchedPatients(string text);

    }
}
