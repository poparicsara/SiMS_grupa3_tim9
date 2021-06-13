using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.IRepository
{
    interface IIngredientRepository : IGenericRepository<Ingredient, string>
    {
        void AddIngredient(Medicament medicament, Ingredient ingredient);
        void DeleteIngredient(Medicament medicament, int index);
        void EditIngredient(Medicament medicament, int index, Ingredient newIngredient);
        List<Ingredient> GetMedicamentIngredients(Medicament medicament);
    }
}
