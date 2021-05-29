using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Services
{
    class MedicamentService
    {
        private MedicamentRepository repository = new MedicamentRepository();
        private Medicament newMedicament = new Medicament();

        public List<Medicament> GetMedicaments()
        {
            return repository.GetMedicaments();
        }

        public void AddMedicament(Medicament newMedicament, string ingredients)
        {
            this.newMedicament = newMedicament;
            this.newMedicament.Ingredients = GetIngredients(ingredients);
            repository.AddMedicament(newMedicament);
        }

        private List<Ingredient> GetIngredients(string ingredients)
        {
            List<Ingredient> ings = new List<Ingredient>();
            string[] parts = ingredients.Split('\n');
            for (int i = 0; i < parts.Length; i++)
            {
                Ingredient ing = GetIngredient(parts, i);
                ings.Add(ing);
            }
            return ings;
        }

        private Ingredient GetIngredient(string[] ingredients, int index)
        {
            string temp = ingredients[index];
            if (ingredients[index].Contains('\r'))
            {
                int endIndex = ingredients[index].IndexOf('\r');
                temp = ingredients[index].Substring(0, endIndex);
            }
            Ingredient ingredient = new Ingredient { Name = temp };
            return ingredient;
        }
    }
}
