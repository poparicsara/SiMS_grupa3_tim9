using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;
using Model;

namespace IS_Bolnica.Services
{
    public class IngredientService
    {
        private IngredientRepository ingredientRepository = new IngredientRepository();
        private PatientService patientService = new PatientService();

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

        public List<Ingredient> GetIngredients()
        {
            return ingredientRepository.loadFromFile("Sastojci.json");
        }

        public List<Ingredient> GetPatientsIngredients(string id)
        {
            Patient patient = patientService.FindPatietnById(id);
            if (patient.Ingredients != null)
            {
                return patient.Ingredients;
            }
            else
            {
                return new List<Ingredient>();
            }
        }

        public List<Ingredient> GetAllOtherIngredients(string id)
        {
            List<Ingredient> ingredients = ingredientRepository.loadFromFile("Sastojci.json");
            List<Ingredient> allOtheriIngredients = new List<Ingredient>();
            List<Ingredient> patientIngredients = GetPatientsIngredients(id);
            if (patientIngredients.Count == 0)
            {
                return ingredients;
            }

            int brojac = 0;

            foreach (var ingredient in ingredients)
            {
                brojac = 0;
                foreach (var patientIngredient in patientIngredients)
                {
                    if (ingredient.Name.Equals(patientIngredient.Name))
                    {
                        brojac++;
                    }
                }

                if (brojac == 0)
                {
                    allOtheriIngredients.Add(ingredient);
                }
            }

            return allOtheriIngredients;
        }
    }
}