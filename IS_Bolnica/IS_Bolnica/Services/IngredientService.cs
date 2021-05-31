using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class IngredientService
    {
        private MedicamentRepository repository = new MedicamentRepository();

        public List<Ingredient> GetIngredients(Medicament medicament)
        {
            return repository.GetIngredients(medicament);
        }

        public void AddIngredient(Medicament medicament, Ingredient ingredient)
        {
            repository.AddIngredient(medicament, ingredient);
        }

        public void DeleteIngredient(Medicament medicament, Ingredient ingredient)
        {
            int index = GetIndex(medicament, ingredient);
            repository.DeleteIngredient(medicament, index);
        }

        public void EditIngredient(Medicament medicament, Ingredient oldIngredient, Ingredient newIngredient)
        {
            int index = GetIndex(medicament, oldIngredient);
            repository.EditIngredient(medicament, index, newIngredient);
        }

        private int GetIndex(Medicament medicament, Ingredient ingredient)
        {
            int index = 0;
            foreach (var i in medicament.Ingredients)
            {
                if (i.Name.Equals(ingredient.Name))
                {
                    break;
                }
                index++;
            }
            return index;
        }

        

    }
}
