using System.Collections.Generic;
using Model;

namespace IS_Bolnica.IRepository
{
    interface IPatientRepository : IGenericRepository<Patient, string>
    {
        void UnblockPatient(Patient patient);
        void SetPatientAllergents(List<Ingredient> ingredients, string id);
    }
}
