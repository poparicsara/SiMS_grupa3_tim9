using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.IRepository
{
    interface IMedicamentRepository : IGenericRepository<Medicament, int>
    {
        List<Ingredient> GetIngredients();
        void AddIngredient(Medicament medicament, Ingredient ingredient);
        Medicament GetMedicamentByName(string name);
        void CheckMedicamentIngredients(Medicament medicament);
        void DeleteIngredient(Medicament medicament, int index);
        void EditIngredient(Medicament medicament, Ingredient ingredient, int index);
        bool HasMedicamentIngredient(Medicament medicament, string ingredient);
        bool IsMedNumberUnique(int medNumber);
        List<Medicament> GetSearchedMeds(string text);



    }
}
