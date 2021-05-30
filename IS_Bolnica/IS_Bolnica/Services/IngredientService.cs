using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    public class IngredientService
    {
        private IngredientRepository ingredientRepository = new IngredientRepository();

        public IngredientService()
        {

        }

        public void RemoveIngredientFromMedicament(Medicament medicament, Ingredient ingredient)
        {
            for (int i = 0; i < medicament.Ingredients.Count; i++)
            {
                if (medicament.Ingredients[i].Name == ingredient.Name)
                {
                    medicament.Ingredients.RemoveAt(i);
                }
            }
        }
    }
}
